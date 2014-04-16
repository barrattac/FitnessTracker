using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DAO
    {
        public string connectionString = "Data Source=WUSJLLPK00KFRC;Initial Catalog=FitnessTracker;Integrated Security=True";
        //public string connectionString = "Data Source=GDC-007\\SQLEXPRESS;Initial Catalog=FitnessTracker;Integrated Security=True";
        public int Write(string statement, SqlParameter[] parameters)
        {

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
