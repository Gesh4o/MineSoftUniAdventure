namespace _05.HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("Image");
            image.AddAttribute("imagesource", imageSource);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);

            return image.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder url0 = new ElementBuilder("URL");
            url0.AddAttribute("url", url);
            url0.AddAttribute("title", title);
            url0.AddAttribute("text", text);

            return url0.ToString();
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("URL");
            input.AddAttribute("url", inputType);
            input.AddAttribute("title", name);
            input.AddAttribute("text", value);

            return input.ToString();
        }
    }
}