using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }
        public string AdminToken { get; set; }
    }
}
