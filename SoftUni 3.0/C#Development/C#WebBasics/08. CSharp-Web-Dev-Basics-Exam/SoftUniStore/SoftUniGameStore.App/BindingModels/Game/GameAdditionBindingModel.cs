namespace SoftUniGameStore.App.BindingModels.Game
{
    using System.Linq;

    public class GameAdditionBindingModel : AbstractBindingModel
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public string VideoUrl { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public override bool IsValid()
        {
            bool isTitleValid = this.Title.Length >= 3 && this.Title.Length <= 100 && this.Title.Any(char.IsUpper);

            bool isPriceValid = this.Price > 0;

            bool isSizeValid = this.Size > 0;

            bool isTrailerValid = this.VideoUrl.Length == 11;

            bool isImageValid = string.IsNullOrEmpty(this.Thumbnail) || this.Thumbnail.StartsWith("http://") || this.Thumbnail.StartsWith("https://");

            bool isDescriptionValid = this.Description.Length > 20;

            return isTitleValid && isPriceValid && isSizeValid && isTrailerValid && isImageValid && isDescriptionValid;
        }
    }
}
