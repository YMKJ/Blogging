using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Blogging.Adapters_Interfaces.DataAdapters
{
    public class PostDataAdapter : IPostsAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Models.Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            posts = db.Posts.Include("Comments")
                //.Where(i => i.Hidden == false)
                            .ToList();
            return posts;
        }

        public Models.Post GetPost(int id)
        {
            Post post = new Post();
            post = db.Posts.Include("Comments")
                                .Where(i => i.PostId == id)
                //.Where(i => i.Hidden == false)
                                .FirstOrDefault();
            return post;
        }

        public Models.Post PostPost(Models.Post newPost)
        {
            ApplicationUser User = new ApplicationUser();
            Post post = new Post();
            post.Title = newPost.Title;
            post.Body = newPost.Body;
            post.PostDate = DateTime.Now;
            post.EditDate = DateTime.Now;
            post.Hidden = newPost.Hidden;
            post.UserId = newPost.UserId;
            db.Posts.Add(post);

            User = db.Users.Where(i => i.Id == post.UserId)
                            .FirstOrDefault();
            User.myPosts.Add(post);
            db.SaveChanges();

            return post;

        }

        public Models.Post PutPost(int id, Models.Post newPost)
        {
            ApplicationUser User = new ApplicationUser();
            Post post = new Post();
            post = db.Posts.Find(id);
            post.Title = newPost.Title;
            post.Body = newPost.Body;
            post.PostDate = DateTime.Now;
            post.EditDate = DateTime.Now;
            post.Hidden = newPost.Hidden;
            post.UserId = newPost.UserId;

            User = db.Users.Where(i => i.Id == post.UserId)
                           .FirstOrDefault();
            var model = User.myPosts.Where(i => i.PostId == id)
                                    .FirstOrDefault();
            User.myPosts.Remove(model);
            User.myPosts.Add(post);

            db.SaveChanges();

            return post;
        }

        public Models.Post DeletePost(int id)
        {
            //List<Post> Posts = new List<Post>();
            //Posts = db.Posts.ToList();

            //ApplicationUser user = new ApplicationUser();
            

            //Post post = new Post();
            //post = db.Posts.Find(id);

            //user = db.Users.Where(i => i.Id == post.UserId)
            //                .FirstOrDefault();

            //user.myPosts.Remove(post);
            //Posts.Remove(post);
            //db.SaveChanges();

            //return post;

            Post post = new Post();
            post = db.Posts.Find(id);
            post.Hidden = true;
            db.SaveChanges();
            return post;
        }


        //public List<Post> GetUserPosts(string id)
        //{
        //    List<Post> Posts = new List<Post>();
        //    Posts = db.Posts.Where(i => i.UserId == id)
        //                    .Where(i=>i.Hidden == false)
        //                    .ToList();
        //    return Posts;
        //}
    }
}