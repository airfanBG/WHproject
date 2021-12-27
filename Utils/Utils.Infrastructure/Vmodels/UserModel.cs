using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Vmodels
{
    public class UserModel
    {
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }

}
