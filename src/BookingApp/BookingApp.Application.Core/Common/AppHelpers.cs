using HashidsNet;

namespace BookingApp.Application.Core.Common
{
    public static class AppHelpers
    {
        public const string HashIdsSalt = "s3cretS4lt";

        public static string ToHashId(this int number) =>
            GetHasher().Encode(number);

        public static int FromHashId(this string encoded) =>
            GetHasher().Decode(encoded).FirstOrDefault();


        private static Hashids GetHasher() => new(HashIdsSalt, 16);
    }
}
