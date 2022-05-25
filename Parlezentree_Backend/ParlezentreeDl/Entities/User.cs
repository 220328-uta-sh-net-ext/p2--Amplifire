using System;
using System.Collections.Generic;

namespace ParlezentreeDl.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public decimal? ContactNo { get; set; } = null!;
    }
}
