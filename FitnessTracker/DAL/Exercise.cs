using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class Exercise
    {
        public int ID { get; set; }
        public string ExerciseName { get; set; }

        public Exercise(SqlDataReader data)
        {
            this.ID = Convert.ToInt32(data["ID"]);
            this.ExerciseName = data["Exercise"].ToString();
        }

        public Exercise()
        {

        }
    }
}