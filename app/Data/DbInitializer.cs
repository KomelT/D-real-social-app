using D_real_social_app.Data;
using D_real_social_app.Models;
using System;
using System.Linq;

namespace D_real_social_app.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SocialAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{UserID=1, Photo="", FirstName="Lojze", LastName="Novak", Email="lojze.novak@gmail.com", Pass="dssaasdsadsadsadsadsadfhf", Usern="lojze.novak"},
                new User{UserID=2, Photo="", FirstName="Janez", LastName="Komel", Email="janez.komel@gmail.com", Pass="dssaasdsadsadsadsadsadfhf", Usern="janez.komel"}
            };

            context.User.AddRange(users);
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post{PostID=1, UserID=1, Text="Hello World, first post."}
            };

            context.Post.AddRange(posts);
            context.SaveChanges();

            var comments = new Comment[]
            {
                new Comment{CommentID=1, UserID=1, PostID=1, Text="First comment."}
            };

            context.Comment.AddRange(comments);
            context.SaveChanges();

            var connections = new Connection[]
            {
                new Connection{ConnectionID=1, UserID=1, UserID2=2}
            };

            context.Comment.AddRange(comments);
            context.SaveChanges();
        }
    }
}