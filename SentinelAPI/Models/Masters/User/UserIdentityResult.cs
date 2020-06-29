using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.User
{
    public class UserIdentityResult
    {
        public int Id { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
