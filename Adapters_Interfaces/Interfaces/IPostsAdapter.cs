using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Adapters_Interfaces
{
    public interface IPostsAdapter
    {
        //Posts
        List<Post> GetPosts();
        Post GetPost(int id);
        Post PostPost(Post newPost);
        Post PutPost(int id, Post newPost);
        Post DeletePost(int id);

        //Get Posts/Blogs of certain users
        //List<Post> GetUserPosts(string id);
    }
}
