namespace Exceptions
{
    public static class StringArrayGenerator
    {
        public static string[] RepeatString(int n, string value)
        {
            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = value;
            }

            return result;
        }
    }
}