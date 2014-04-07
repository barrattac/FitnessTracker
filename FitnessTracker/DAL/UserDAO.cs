using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAO : DAO
    {
        public List<User> ReadUsers(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<User> users = new List<User>();
                    while (data.Read())
                    {
                        User user = new User(data);
                        users.Add(user);
                    }
                    try
                    {
                        return users;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public List<User> GetUser()
        {
            return ReadUsers("GetAllUsers", null);
        }

        public User GetUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Email", user.Email)
            };
            try
            {
                return ReadUsers("GetUser", parameters)[0];
            }
            catch
            {
                return null;
            }
        }

        public int CreateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName)
            };
            return Write("CreateUser", parameters);
        }
    }
}