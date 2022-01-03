using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
