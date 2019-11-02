using GS.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GS.DataBaseTest
{
    public class ReviewRepositoryTest
    {

        public ReviewRepositoryTest() { }

        public UnitOfWork UnitOfWork { get; set; }

        public UnitOfWork GetOption(string name)
        {
            var options = new DbContextOptionsBuilder<GSDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;

            var context = new GSDbContext(options);

            UnitOfWork = new UnitOfWork(context);

            return UnitOfWork;

        }

        [Fact]
        public async Task Get()
        {

            UnitOfWork = GetOption("TestGetReview");

            var expectedReview = new DataBase.Entities.Review()
            {
                Id = 1,
                UserId = Guid.NewGuid(),
                PlaceId = 1,
                Rating = 4,
                Text = "This is picturesque cathedral, I love it"
            };

            UnitOfWork.ReviewRepository.Create(expectedReview);

            UnitOfWork.Commit();

            var review = await UnitOfWork.ReviewRepository.Get(1);

            Assert.Equal(expectedReview.Id, review.Id);

            Assert.Equal(expectedReview.UserId, review.UserId);

            Assert.Equal(expectedReview.PlaceId, review.PlaceId);

            Assert.Equal(expectedReview.Rating, review.Rating);

            Assert.Equal(expectedReview.Text, review.Text);

        }

        [Fact]
        public async Task Create()
        {

            UnitOfWork = GetOption("TestGetReview");

            var expectedReview = new DataBase.Entities.Review()
            {
                Id = 1,
                UserId = Guid.NewGuid(),
                PlaceId = 1,
                Rating = 4,
                Text = "This is picturesque cathedral, I love it"
            };

            UnitOfWork.ReviewRepository.Create(expectedReview);

            UnitOfWork.Commit();

            var review = await UnitOfWork.ReviewRepository.Get(1);

            Assert.Equal(expectedReview.Id, review.Id);

            Assert.Equal(expectedReview.UserId, review.UserId);

            Assert.Equal(expectedReview.PlaceId, review.PlaceId);

            Assert.Equal(expectedReview.Rating, review.Rating);

            Assert.Equal(expectedReview.Text, review.Text);

        }

        [Fact]
        public async Task GetAll()
        {

            UnitOfWork = GetOption("TestGetAllReview");


            var reviews = new List<DataBase.Entities.Review>()
            {
                new DataBase.Entities.Review()
                {
                    Id = 1,
                    UserId = Guid.NewGuid(),
                    PlaceId = 1,
                    Rating = 4,
                    Text = "This is picturesque cathedral, I love it"
                },

                new DataBase.Entities.Review()
                {
                    Id = 2,
                    UserId = Guid.NewGuid(),
                    PlaceId = 2,
                    Rating = 5,
                    Text = "Amazing place!"
                }
            };

            UnitOfWork.ReviewRepository.Create(reviews[0]);

            UnitOfWork.ReviewRepository.Create(reviews[1]);

            UnitOfWork.Commit();

            var test = await UnitOfWork.ReviewRepository.GetAll();

            List<DataBase.Entities.Review> review = test.ToList();

            Assert.Equal(2, review.Count());

        }

        [Fact]
        public async Task Update()
        {

            UnitOfWork = GetOption("TestUpdateReview");


            var expectedReview = new DataBase.Entities.Review()
            {
                Id = 1,
                UserId = Guid.NewGuid(),
                PlaceId = 1,
                Rating = 4,
                Text = "This is picturesque cathedral, I love it"
            };

            UnitOfWork.ReviewRepository.Create(expectedReview);

            UnitOfWork.Commit();

            expectedReview.Id = 4;

            UnitOfWork.ReviewRepository.Update(expectedReview);

            var test = await UnitOfWork.ReviewRepository.Get(1);

            Assert.Equal(expectedReview.Id, test.Id);

        }

        [Fact]
        public async Task Delete()
        {

            UnitOfWork = GetOption("TestDeleteReview");


            var reviews = new List<DataBase.Entities.Review>()
            {
                new DataBase.Entities.Review()
                {
                    Id = 1,
                    UserId = Guid.NewGuid(),
                    PlaceId = 1,
                    Rating = 4,
                    Text = "This is picturesque cathedral, I love it"
                },

                new DataBase.Entities.Review()
                {
                    Id = 2,
                    UserId = Guid.NewGuid(),
                    PlaceId = 2,
                    Rating = 5,
                    Text = "Amazing place!"
                }
            };

            UnitOfWork.ReviewRepository.Create(reviews[0]);

            UnitOfWork.ReviewRepository.Create(reviews[1]);

            UnitOfWork.ReviewRepository.Delete(1);

            UnitOfWork.Commit();

            var test = await UnitOfWork.ReviewRepository.GetAll();

            List<DataBase.Entities.Review> review = test.ToList();

            Assert.Equal(1, review.Count());

        }

    }
}
