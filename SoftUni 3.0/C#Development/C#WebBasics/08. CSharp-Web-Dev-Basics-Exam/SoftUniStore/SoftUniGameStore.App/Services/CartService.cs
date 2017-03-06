namespace SoftUniGameStore.App.Services
{
    using System.Linq;

    using Data.Interfaces;

    using SoftUniGameStore.Models;

    public class CartService
    {
        private IUnitOfWork unitOfWork;

        private IRepository<Cart> cartRepository;

        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartRepository = cartRepository;
        }

        public Cart FindBySession(string sid)
        {
            return this.cartRepository.Get(c => c.SessionId == sid).FirstOrDefault();
        }

        public void Add(Cart cart)
        {
            this.cartRepository.Insert(cart);
            this.unitOfWork.Save();
        }
    }
}
