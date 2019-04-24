using System;

namespace Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public int PostId { get; set; }
    }
}
