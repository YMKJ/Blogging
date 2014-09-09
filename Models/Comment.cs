using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Blogging.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentBody { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CommentDate { get; set; }

        public bool Hidden { get; set; }

        //Foreign Key
        public int PostId { get; set; }
    }
}
