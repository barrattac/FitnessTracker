using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class WorkoutDAO : DAO
    {
        public List<Workout> ReadWorkouts(string statement, SqlParameter[] parameters)
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
                    List<Workout> workouts = new List<Workout>();
                    while (data.Read())
                    {
                        Workout workout = new Workout(data);
                        workouts.Add(workout);
                    }
                    try
                    {
                        return workouts;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public List<Workout> GetWorkouts(int userID, DateTime date)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserID", userID), 
                new SqlParameter("@Date", date)
            };
            try
            {
                return ReadWorkouts("GetUserWorkout", parameters);
            }
            catch
            {
                return null;
            }
        }
    }
}