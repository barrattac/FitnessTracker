using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class WeightDAO : DAO
    {
        public List<Weight> ReadWeights(string statement, SqlParameter[] parameters)
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
                    List<Weight> weights = new List<Weight>();
                    while (data.Read())
                    {
                        Weight weight = new Weight(data);
                        weights.Add(weight);
                    }
                    try
                    {
                        return weights;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public List<Weight> GetUserWeights(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserID", userID)
            };
            return ReadWeights("GetUserWeights", parameters);
        }
    }
}
