namespace SoftUniGameStore.App.Views.Home
{
    using System.Text;

    using SimpleMVC.Interfaces.Generic;

    using ViewModels.Cart;

    using static Utilities.HtmlProvider;

    public class Cart : IRenderable<CartViewModel>
    {
        public CartViewModel Model { get; set; }

        public string Render()
        {
            string layout = ProvideLayout(this.Model.Email);
            string content = ProvideCart();

            StringBuilder gameStringBuilder = new StringBuilder();

            foreach (CartGameViewModel cartGame in this.Model.Games)
            {
                gameStringBuilder.Append(
                    string.Format(
                        ProvideCartGamePartial(),
                        cartGame.VideoUrl,
                        cartGame.Thumbnail,
                        cartGame.Title,
                        cartGame.Description,
                        cartGame.Price,
                        cartGame.Id));
            }

            content = string.Format(content, gameStringBuilder, this.Model.TotalPrice);
            return string.Format(layout, content);
        }
    }
}
