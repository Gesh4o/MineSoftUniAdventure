namespace SoftUniGameStore.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

    using BindingModels.Game;

    using Data.Interfaces;

    using SoftUniGameStore.Models;

    using ViewModels.Games;

    public class GameService
    {
        private IUnitOfWork unitOfWork;

        private IRepository<Game> gameRepository;

        public GameService(IUnitOfWork unitOfWork, IRepository<Game> gameRepository)
        {
            this.unitOfWork = unitOfWork;
            this.gameRepository = gameRepository;
        }

        public void Insert(GameAdditionBindingModel gameBindingModel)
        {
            Game game = new Game
            {
                Title = gameBindingModel.Title,
                Price = gameBindingModel.Price,
                Size = gameBindingModel.Size,
                VideoUrl = gameBindingModel.VideoUrl,
                Description = gameBindingModel.Description,
                ReleaseDate = DateTime.ParseExact(gameBindingModel.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                ImageThumbnail = gameBindingModel.Thumbnail
            };

            this.gameRepository.Insert(game);
            this.unitOfWork.Save();
        }

        public IEnumerable<Game> GetAll()
        {
            return this.gameRepository.GetAll();
        }

        public IEnumerable<Game> GetAllBy(Expression<Func<Game, bool>> filter = null)
        {
            return this.gameRepository.Get(filter);
        }

        public Game Find(int id)
        {
            Game game = this.gameRepository.GetById(id);
            return game;
        }

        public void Delete(int id)
        {
            Game game = this.gameRepository.GetById(id);
            this.gameRepository.Delete(game);
            this.unitOfWork.Save();
        }

        public void Update(GameUpdateBindingModel gameVM)
        {
            Game game = this.gameRepository.GetById(gameVM.Id);
            game.Title = gameVM.Title;
            game.Description = gameVM.Description;
            game.Size = gameVM.Size;
            game.ReleaseDate = DateTime.ParseExact(gameVM.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            game.VideoUrl = gameVM.VideoUrl;
            game.Price = gameVM.Price;
            
            this.gameRepository.Update(game);
            this.unitOfWork.Save();
        }
    }
}
