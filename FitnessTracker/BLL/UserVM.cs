using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserVM
    {
        private int p;

        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserVM(int userID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(userID);
            this.ID = user.ID;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
        }

        public UserVM(User user)
        {
            this.ID = user.ID;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
        }

        public UserVM()
        {

        }

    }
}
