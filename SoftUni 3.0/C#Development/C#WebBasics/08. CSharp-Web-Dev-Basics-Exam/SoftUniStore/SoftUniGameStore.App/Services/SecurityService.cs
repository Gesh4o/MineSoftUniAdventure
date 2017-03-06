namespace SoftUniGameStore.App.Services
{
    using System.Linq;

    using BindingModels.User;

    using Data.Interfaces;

    using SimpleHttpServer.Models;

    using SoftUniGameStore.Models;

    public class SecurityService
    {
        private IUnitOfWork unitOfWork;

        private IRepository<Login> loginRepository;

        private IRepository<User> userRepository;

        public SecurityService(IUnitOfWork unitOfWork, IRepository<Login> loginRepository, IRepository<User> userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.loginRepository = loginRepository;
            this.userRepository = userRepository;
        }

        public bool HasLogin(HttpSession session, UserAuthenticationBindingModel userBindingModel)
        {
            if (session == null || userBindingModel == null || !userBindingModel.IsValid())
            {
                return false;
            }

            User currentUser = this.userRepository
                .Get(u => u.Email == userBindingModel.Email)
                .FirstOrDefault();

            if (currentUser != null)
            {
                Login login = new Login
                {
                    IsActive = true,
                    SessionId = session.Id,
                    UserId = currentUser.Id
                };

                this.loginRepository.Insert(login);
                this.unitOfWork.Save();
                return true;
            }

            return false;
        }

        public bool HasLogout(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }

            Login login = this.loginRepository.Get(l => l.SessionId == session.Id).FirstOrDefault();

            if (login != null)
            {
                login.IsActive = false;
                this.loginRepository.Update(login);
                this.unitOfWork.Save();
                return true;
            }

            return false;
        }

        public bool HasRegister(UserRegisterBindingModel userBindingModel)
        {
            if (userBindingModel == null || !userBindingModel.IsValid())
            {
                return false;
            }

            if (this.userRepository.GetAll().Any(u => u.Email == userBindingModel.Email))
            {
                return false;
            }

            User user = new User
            {
                Email = userBindingModel.Email,
                Password = userBindingModel.Password,
                FullName = userBindingModel.Name,
                IsAdministrator = !this.userRepository.GetAll().Any()
            };

            this.userRepository.Insert(user);
            this.unitOfWork.Save();

            return true;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.GetCurrentlyLoggedUser(session) != null;
        }

        public bool IsAdmin(HttpSession session)
        {
            User currentUser = this.GetCurrentlyLoggedUser(session);
            return currentUser != null && currentUser.IsAdministrator;
        }

        public User GetCurrentlyLoggedUser(HttpSession session)
        {
            return this.loginRepository.Get(l => l.SessionId == session.Id).Select(l => l.User).FirstOrDefault();
        }
    }
}
