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

        [Fact]
        public async Task Get()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetReview"))
            {
                var expectedReview = new DataBase.Entities.Review()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    Rating = 4,
                    Text = "This is picturesque cathedral, I love it"
                };

                unitOfWork.ReviewRepository.Create(expectedReview);

                await unitOfWork.Commit().ConfigureAwait(true);

                var review = await unitOfWork.ReviewRepository.Get(expectedReview.Id).ConfigureAwait(true);

                Assert.Equal(expectedReview.Id, review.Id);

                Assert.Equal(expectedReview.UserId, review.UserId);

                Assert.Equal(expectedReview.PlaceId, review.PlaceId);

                Assert.Equal(expectedReview.Rating, review.Rating);

                Assert.Equal(expectedReview.Text, review.Text);
            }
        }

        [Fact]
        public async Task Create()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetReview"))
            {
                var expectedReview = new DataBase.Entities.Review()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    Rating = 4,
                    Text = "This is picturesque cathedral, I love it"
                };

                unitOfWork.ReviewRepository.Create(expectedReview);

                await unitOfWork.Commit().ConfigureAwait(true);

                var review = await unitOfWork.ReviewRepository.Get(expectedReview.Id).ConfigureAwait(true);

                Assert.Equal(expectedReview.Id, review.Id);

                Assert.Equal(expectedReview.UserId, review.UserId);

                Assert.Equal(expectedReview.PlaceId, review.PlaceId);

                Assert.Equal(expectedReview.Rating, review.Rating);

                Assert.Equal(expectedReview.Text, review.Text);
            }
        }

        [Fact]
        public async Task GetAll()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestGetAllReview"))
            {
                var reviews = new List<DataBase.Entities.Review>()
                {
                    new DataBase.Entities.Review()
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        Rating = 4,
                        Text = "This is picturesque cathedral, I love it"
                    },
                    new DataBase.Entities.Review()
                    {
                       Id = Guid.NewGuid(),
                       UserId = Guid.NewGuid(),
                       PlaceId = Guid.NewGuid(),
                       Rating = 5,
                       Text = "Amazing place!"
                    }
                };

                unitOfWork.ReviewRepository.Create(reviews[0]);

                unitOfWork.ReviewRepository.Create(reviews[1]);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.ReviewRepository.GetAll().ConfigureAwait(true);

                var length = test.ToList().Count;

                Assert.Equal(2, length);
            }
        }

        [Fact]
        public async Task Update()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestUpdateReview"))
            {
                var expectedReview = new DataBase.Entities.Review()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    PlaceId = Guid.NewGuid(),
                    Rating = 4,
                    Text = "This is picturesque cathedral, I love it"
                };

                unitOfWork.ReviewRepository.Create(expectedReview);

                await unitOfWork.Commit().ConfigureAwait(true);

                var newReviewId = Guid.NewGuid();
                expectedReview.Id = newReviewId;

                unitOfWork.ReviewRepository.Update(expectedReview);

                var test = await unitOfWork.ReviewRepository.Get(newReviewId).ConfigureAwait(true);

                Assert.Equal(expectedReview.Id, test.Id);
            }
        }

        [Fact]
        public async Task Delete()
        {
            using (var unitOfWork = Utils.GetUnitOfWork("TestDeleteReview"))
            {
                var reviews = new List<DataBase.Entities.Review>()
                {
                    new DataBase.Entities.Review()
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        Rating = 4,
                        Text = "This is picturesque cathedral, I love it"
                    },
                    new DataBase.Entities.Review()
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        PlaceId = Guid.NewGuid(),
                        Rating = 5,
                        Text = "Amazing place!"
                    }
                };

                unitOfWork.ReviewRepository.Create(reviews[0]);

                unitOfWork.ReviewRepository.Create(reviews[1]);

                unitOfWork.ReviewRepository.Delete(reviews[0].Id);

                await unitOfWork.Commit().ConfigureAwait(true);

                var test = await unitOfWork.ReviewRepository.GetAll().ConfigureAwait(true);

                List<DataBase.Entities.Review> review = test.ToList();

                Assert.Single(review);
            }
        }

    }
}
