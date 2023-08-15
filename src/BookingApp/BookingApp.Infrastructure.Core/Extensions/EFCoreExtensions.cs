﻿using BookingApp.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingApp.Infrastructure.Core.Extensions
{
    public static class EFCoreExtensions
    {
        public static async Task<PagedResult<TEntity>> GetPagedResultAsync<TEntity>(this IQueryable<TEntity> source, int pageSize, int currentPage)
            where TEntity : class
        {
            var rows = source.Count();
            var results = await source
                .Skip(pageSize * (currentPage - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TEntity>
            {
                CurrentPage = currentPage,
                PageCount = (int)Math.Ceiling((double)rows / pageSize),
                PageSize = pageSize,
                Results = results,
                RowsCount = rows
            };
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByStrValues)
            where TEntity : class
        {
            var queryExpr = source.Expression;
            var command = orderByStrValues.ToUpper().EndsWith("DESC") ? "OrderByDescending" : "OrderBy";
            var propertyName = orderByStrValues.Split(' ')[0].Trim();

            var type = typeof(TEntity);
            var property = type.GetProperties()
            .Where(item => item.Name.ToLower() == propertyName.ToLower())
            .FirstOrDefault();

            if (property == null)
                return source;
                        
            var parameter = Expression.Parameter(type, "p");            
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);            
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            
            queryExpr = Expression.Call(
                type: typeof(Queryable),
                methodName: command,
                typeArguments: new Type[] { type, property.PropertyType },
                queryExpr,
                Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(queryExpr); ;
        }
    }
}
