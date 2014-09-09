using Blogging.Adapters_Interfaces;
using Blogging.Adapters_Interfaces.DataAdapters;
using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogging.Controllers
{
    public class apiPostController : ApiController
    {
        IPostsAdapter _adapter;

        public apiPostController()
        {
            _adapter = new PostDataAdapter();
        }
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var posts = _adapter.GetPosts();
            return Ok(posts);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Post post = new Post();
            post = _adapter.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Post newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PostPost(newPost);
            return CreatedAtRoute("postApi", new { newPost.PostId }, newPost);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Post newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutPost(id, newPost));
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeletePost(id));
        }


        //// GET api/<controller>/userID
        //public IHttpActionResult Get(string id)
        //{
        //    var posts = _adapter.GetUserPosts(id);
        //    return Ok(posts);
        //}
    }
}