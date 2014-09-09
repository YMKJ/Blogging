using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging.ViewModels
{
    public class UserPostVM
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}