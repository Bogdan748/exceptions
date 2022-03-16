using System;


namespace Exceptions
{
    public static class ConversionHelper
    {
        public static int ToInt(string value, int defaultValue = 0)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return defaultValue;
                }


                char[] chars = value.ToCharArray();
                foreach(char c in chars)
                {
                    if (!char.IsDigit(c))
                    {
                        return defaultValue;
                    }
                }

                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ToInt_Faster(string value, int defaultValue = 0)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return defaultValue;
        }
    }
}
