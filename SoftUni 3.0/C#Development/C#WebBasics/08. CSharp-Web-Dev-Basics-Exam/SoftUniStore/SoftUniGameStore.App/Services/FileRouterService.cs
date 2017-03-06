namespace SoftUniGameStore.App.Services
{
    using System;
    using System.IO;

    using SimpleHttpServer;
    using SimpleHttpServer.Models;

    using SoftUniGameStore.App.Services.Models;

    public class FileRouterService
    {
        public HttpResponse Handle(HttpRequest request, string fileDirectory)
        {
            try
            {
                HttpFile file = this.ServeFile(request, fileDirectory);
                HttpResponse response = new HttpResponse
                {
                    Content = file.Content,
                    Header = { ContentType = file.MimeType },
                };

                return response;
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.ToString());

                return HttpResponseBuilder.NotFound();
            }
        }

        private static string GetMimeType(string fileExtension)
        {
            string mimeType = string.Empty;

            switch (fileExtension)
            {
                case "js":
                    mimeType = "application/javascript";
                    break;

                case "html":
                    mimeType = "text/html";
                    break;

                case "css":
                    mimeType = "text/css";
                    break;

                case "png":
                    mimeType = "image/png";
                    break;

                case "jpg":
                    mimeType = "image/jpg";
                    break;

                case "ico":
                    mimeType = "image/x-icon";
                    break;
            }

            return mimeType;
        }

        private static string GetFileExtension(string url)
        {
            int lastIndexOfPoint = url.LastIndexOf('.');

            if (lastIndexOfPoint <= 0)
            {
                return null;
            }

            string extension = url.Substring(lastIndexOfPoint + 1);

            return extension;
        }

        private HttpFile ServeFile(HttpRequest request, string fileDirectory)
        {
            string url = request.Url;

            string fileExtension = GetFileExtension(url);
            string mimeType = GetMimeType(fileExtension);

            HttpFile file = new HttpFile()
            {
                Content = File.ReadAllBytes(fileDirectory),
                MimeType = mimeType,
            };

            return file;
        }
    }
}
