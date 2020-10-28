namespace Delpin.Framework
{
    public static class StringTools
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}