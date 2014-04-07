using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserFM
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserFM()
        {

        }
    }
}
