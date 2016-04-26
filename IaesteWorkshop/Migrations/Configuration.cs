using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Channels;

namespace IaesteWorkshop.Migrations
{
    using IaesteWorkshop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IaesteWorkshop.DB.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private Movie[] GetInitialMovies()
        {
            var movies = new List<Movie>(50);
            for (int i = 0; i < 50; i++)
            {
                var movie = new Movie
                {
                    Title = "Fake Movie" + (i + 1),
                    Description = "With our time on Earth coming to an end, a team of explorers undertakes the most important mission in human history: traveling beyond this galaxy to discover whether mankind has a future among the stars.",
                    TrailerUrl = "https://www.youtube.com/embed/zSWdZVtXT7E",
                    Cast = "Will Smith, Margot Robbie, Adrian Martinez, Rodrigo Santoro, BD Wong, Robert Taylor",
                    Direction = "Glenn Ficarra, John Requa",
                    Duration = TimeSpan.Parse("01:45:00"),
                    Genre = "Crime",
                };
                movies.Add(movie);
            }
            return movies.ToArray();
        }

        private MovieFile[] GetInitialCoverImages(Movie[] movies)
        {
            var count = movies.Length;
            var coverImages = new List<MovieFile>(count);
            for (int i = 0; i < count; i++)
            {
                var fileName = "gridallbum" + (i % 10 + 1) + ".jpg";
                var fakeFileName = "gridallbum" + (i) + ".jpg";
                var filePathRelative = "~/images/" + fileName;
                var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
                var directoryName = Path.GetDirectoryName(absolutePath);
                var filePathAbsolute = Path.Combine(System.Web.HttpUtility.UrlDecode(directoryName), ".." + filePathRelative.TrimStart('~').Replace('/', '\\'));

                using (var coverImage = Image.FromFile(filePathAbsolute))
                {
                    using (var ms = new MemoryStream())
                    {
                        coverImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        var bytes = ms.ToArray();
                        coverImages.Add(new MovieFile
                        {
                            Content = bytes,
                            ContentType = "image/jpeg",
                            FileName = fakeFileName,
                            MovieId = movies.ElementAt(i).Id,
                        });
                    }
                }
            }
            return coverImages.ToArray();
        }

        private MovieReview[] GetInitialReviews(Movie[] movies)
        {
            var reviews = new List<MovieReview>();
            for (int i = 0; i < movies.Length; i++)
            {
                reviews.Add(new MovieReview
                {
                    MovieId = movies.ElementAt(i).Id,
                    ReviewType = MoviewReviewType.Expert,
                    Rating = (MovieReviewRating)((int)((i % 5+1) * 2)),
                    ReviewerName = "Fake Expert" + (i + 1),
                    ReviewerEmail = "FakeExpertEmail" + (i + 1) + "@mailinator.com",
                });
                reviews.Add(new MovieReview
                {
                    MovieId = movies.ElementAt(i).Id,
                    ReviewType = MoviewReviewType.Reader,
                    Rating = (MovieReviewRating)((int)((i * i) % 5+1) * 2),
                    ReviewerName = "Fake reader" + (i + 1),
                    ReviewerEmail = "FakeReaderEmail" + (i + 1) + "@mailinator.com",
                });
            }
            return reviews.ToArray();
        }

        private MovieComment[] GetInitialComments(Movie[] movies)
        {
            var comments = new List<MovieComment>();
            for (int i = 0; i < movies.Length; i++)
            {
                comments.Add(new MovieComment
                {
                    MovieId = movies.ElementAt(i).Id,
                    AuthorName = "Fake reader Paul" + (i + 1),
                    AuthorEmail  = "FakeReaderPaulEmail" + (i + 1) + "@mailinator.com",
                    Comment = "But I must explain to you how all this idea denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound but because those who do not know how to pursue pleasure rationally encounter consequences.",
                    CreateTime = DateTime.Now
                });
                comments.Add(new MovieComment
                {
                    MovieId = movies.ElementAt(i).Id,
                    AuthorName = "Fake reader Ann" + (i + 1),
                    AuthorEmail = "FakeReaderAnnEmail" + (i + 1) + "@mailinator.com",
                    Comment = "But I must explain to you how all this idea denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound but because those who do not know how to pursue pleasure rationally encounter consequences.",
                    CreateTime = DateTime.Now
                });
            }
            return comments.ToArray();
        }

        protected override void Seed(IaesteWorkshop.DB.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Movies.AddOrUpdate(
              p => p.Title,
               GetInitialMovies()
            );

            var allMovies = context.Movies.ToArray();
            context.MovieFiles.AddOrUpdate(
                x => x.FileName,
                GetInitialCoverImages(allMovies)
            );

            var movies = allMovies.Take(10).ToArray();
            context.MovieReviews.AddOrUpdate(
                x=>x.ReviewerName,
                GetInitialReviews(movies)
            );

            context.MovieComments.AddOrUpdate(
               x => x.AuthorName,
               GetInitialComments(allMovies)
           );
        }
    }
}
