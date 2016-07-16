namespace Blog
{
    using System;
    using System.Linq;

    public class BlogMain
    {
        public static void Main(string[] args)
        {
            BlogDbContext db = new BlogDbContext();
        }

        private static void RemovePosts(BlogDbContext db)
        {
            var post = db.Posts.FirstOrDefault(p => p.Id == 31);
            post.Tags.Clear();
            db.Comments.RemoveRange(post.Comments);
            db.Posts.Remove(post);
            db.SaveChanges();
        }

        private static void UpdateData(BlogDbContext db)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == 2);
            user.FullName = "Gero Ivanov";
            db.SaveChanges();
            Console.WriteLine(db.Users.FirstOrDefault(u => u.Id == 2).FullName);
        }

        private static void AddPost(BlogDbContext db)
        {
            var post = new Posts { Title = "New title", AuthorId = 3, Body = "New body", Date = DateTime.Now };
            db.Posts.Add(post);
            db.SaveChanges();
        }

        private static void PrintAuthors(BlogDbContext db)
        {
            var authors =
                db.Users.Where(u => u.Posts.Count > 0)
                    .Select(u => new { u.UserName, u.FullName, u.Id })
                    .OrderByDescending(u => u.Id)
                    .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine("Username: {0}", author.UserName);
                Console.WriteLine("Full name: {0}", author.FullName);
            }
        }

        private static void PrintSpecificAuthor(BlogDbContext db)
        {
            var author =
                db.Users.Select(u => u)
                    .SelectMany(u => u.Posts, (u, p) => new { u.UserName, PostId = p.Id })
                    .Single(p => p.PostId == 4);

            Console.WriteLine("Username: {0}", author.UserName);
        }

        private static void PrintAllUsernamesWithPostTitles(BlogDbContext db)
        {
            var users = db.Users.SelectMany(u => u.Posts, (u, p) => new { u.UserName, p.Title }).ToList();
            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Post title: {0}", user.Title);
                Console.WriteLine();
            }
        }

        private static void PrintAllAuthors(BlogDbContext db)
        {
            var authors = db.Users.Select(u => u).Where(u => u.Posts.Count > 0).ToList();
            foreach (var author in authors)
            {
                Console.WriteLine("Username: {0}", author.UserName);
                Console.WriteLine("Full name: {0}", author.FullName);
                Console.WriteLine("Posts count: {0}", author.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void PrintUsersOrderedByUsernameDescending(BlogDbContext db)
        {
            var users = db.Users.Select(u => new { u.FullName, u.UserName }).ToList().OrderByDescending(u => u.UserName).ThenByDescending(u => u.FullName);
            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void PrintUsersOrderedByUsername(BlogDbContext db)
        {
            var users = db.Users.Select(u => new { u.FullName, u.UserName }).ToList().OrderBy(u => u.UserName);
            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full name: {0}", user.FullName);
                Console.WriteLine();
            }
        }

        private static void PrintAllPostTitleAndBody(BlogDbContext db)
        {
            var posts = db.Posts.Select(p => new { p.Title, p.Body }).ToList();
            foreach (var post in posts)
            {
                Console.WriteLine(post.Title);
                Console.WriteLine(post.Body);
                Console.WriteLine();
            }
        }

        private static void PrintAllUsers(BlogDbContext db)
        {
            var users = db.Users.Select(u => u).ToList();
            foreach (var user in users)
            {
                Console.WriteLine("Username: {0}", user.UserName);
                Console.WriteLine("Full name: {0}", user.FullName);
                Console.WriteLine("Comments count: {0}", user.Comments.Count);
                Console.WriteLine("Posts count: {0}", user.Posts.Count);
                Console.WriteLine();
            }
        }

        private static void PrintAllPosts(BlogDbContext db)
        {
            var posts = db.Posts.Select(p => p).ToList();
            foreach (Posts post in posts)
            {
                Console.WriteLine("Title: {0}", post.Title);
                Console.WriteLine("AuthorId: {0}", post.AuthorId);
                Console.WriteLine("Comments count: {0}", post.Comments.Count);
                Console.WriteLine("Tag count: {0}", post.Tags.Count);
                Console.WriteLine();
            }
        }
    }
}
