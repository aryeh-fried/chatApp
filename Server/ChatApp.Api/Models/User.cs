using System;
using System.Collections.Generic;

namespace ChatApp.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Conversation> Conversations { get; set; } = [];
    }
}
