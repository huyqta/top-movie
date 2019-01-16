using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbComment
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MovieId { get; set; }
        public string ReplyCommentId { get; set; }
        public DateTime PostedDatetime { get; set; }
        public byte IsValidated { get; set; }
    }
}
