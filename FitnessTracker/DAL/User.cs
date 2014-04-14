using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(SqlDataReader data)
        {
            this.ID = Convert.ToInt32(data["ID"]);
            this.Email = data["Email"].ToString();
            this.Password = data["Password"].ToString();
            this.FirstName = data["FirstName"].ToString();
            this.LastName = data["LastName"].ToString();
        }

        public User()
        {

        }
    }
}