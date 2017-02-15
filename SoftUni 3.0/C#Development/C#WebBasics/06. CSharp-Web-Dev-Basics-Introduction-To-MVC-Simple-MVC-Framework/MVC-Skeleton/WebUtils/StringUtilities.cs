namespace WebUtils
{
    public static class StringUtilities
    {
        /// <summary>
        /// Replaces the first char with lowercase one (if possible).
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCamelCase(string text)
        {
            return text[0].ToString().ToLower() + text.Substring(1);
        }


        /// <summary>
        /// Replaces the first char with uppercase one (if possible).
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToTitleCase(string text)
        {
            string firstChar = text[0].ToString();
            return firstChar.ToUpper() + text.Substring(1);
        }
    }
}
