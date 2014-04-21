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

        public int UpdateWeight(Weight weight)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Weight", weight.Pounds),
                new SqlParameter("@Date", weight.Date)
            };
            return Write("UpdateUserWeight", parameters);
        }

        public int UpdatePushupMax(Max max)
        {
            SqlParameter[] parameters = MaxParameters(max);
            return Write("UpdateUserPushupMax", parameters);
        }

        public int UpdateSitupMax(Max max)
        {
            SqlParameter[] parameters = MaxParameters(max);
            return Write("UpdateUserSitupMax", parameters);
        }

        public int UpdatePullupMax(Max max)
        {
            SqlParameter[] parameters = MaxParameters(max);
            return Write("UpdateUserPullupMax", parameters);
        }

        private SqlParameter[] MaxParameters(Max max)
        {
            return new SqlParameter[]{
                new SqlParameter("@Amount", max.Amount),
                new SqlParameter("@Date", max.Date)
            };
        }

        public int UpdateStats(Max max, string type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@UserID", max.UserID);
            switch (type)
            {
                case "weight":
                    parameters[1] = new SqlParameter("@Weight", max.Amount);
                    break;
                case "pushup":
                    parameters[1] = new SqlParameter("@Pushup", max.Amount);
                    break;
                case "situp":
                    parameters[1] = new SqlParameter("@Situp", max.Amount);
                    break;
                case "pullup":
                    parameters[1] = new SqlParameter("@Pullup", max.Amount);
                    break;
            }
            return Write("UpdateUserStats", parameters);
        }
    }
}