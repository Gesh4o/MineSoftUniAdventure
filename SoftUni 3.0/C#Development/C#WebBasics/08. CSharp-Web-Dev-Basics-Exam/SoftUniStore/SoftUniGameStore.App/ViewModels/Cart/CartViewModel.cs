namespace SoftUniGameStore.App.ViewModels.Cart
{
    using System.Collections.Generic;

    public class CartViewModel
    {
        public IEnumerable<CartGameViewModel> Games { get; set; }

        public string Sid { get; set; }

        public string Email { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
