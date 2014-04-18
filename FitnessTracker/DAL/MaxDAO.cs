using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class MaxDAO : DAO
    {
        public List<Max> ReadMaxes(string statement, SqlParameter[] parameters, string type)
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
                    List<Max> maxes = new List<Max>();
                    while (data.Read())
                    {
                        Max max = new Max(data, type);
                        maxes.Add(max);
                    }
                    try
                    {
                        return maxes;
                    }
                    catch
                    {
                        return new List<Max>();
                    }
                }
            }
        }

        public List<Max> GetUserMaxes(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserID", userID)
            };
            SqlParameter[] parameters2 = new SqlParameter[]{
                new SqlParameter("@UserID", userID)
            };
            SqlParameter[] parameters3 = new SqlParameter[]{
                new SqlParameter("@UserID", userID)
            };
            List<Max> maxes = ReadMaxes("GetUserMaxPushups", parameters, "Pushups");
            maxes.AddRange(ReadMaxes("GetUserMaxSitups", parameters2, "Situps"));
            maxes.AddRange(ReadMaxes("GetUserMaxPullups", parameters3, "Pullups"));
            return maxes;
        }
    }
}