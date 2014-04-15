using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ExerciseDAO : DAO
    {
        public List<Exercise> ReadExercises(string statement, SqlParameter[] parameters)
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
                    List<Exercise> exercises = new List<Exercise>();
                    while (data.Read())
                    {
                        Exercise exercise = new Exercise(data);
                        exercises.Add(exercise);
                    }
                    try
                    {
                        return exercises;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public Exercise GetExerciseByID(int exerciseID)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", exerciseID)
            };
            try
            {
                return ReadExercises("GetExerciseByID", parameters)[0];
            }
            catch
            {
                return null;
            }
        }

        public List<Exercise> GetExercises()
        {
            return ReadExercises("GetAllExercises", null);
        }

        public int AddExercise(string exerciseName)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ExerciseName", exerciseName)
            };
            return Write("AddExercise", parameters);
        }
    }
}