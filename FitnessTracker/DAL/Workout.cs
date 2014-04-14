using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Workout
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ExerciseID { get; set; }
        public int NumberSets { get; set; }
        public int Amount { get; set; }
        public DateTime PlanDate { get; set; }

        public Workout(SqlDataReader data)
        {
            this.ID = Convert.ToInt32(data["ID"]);
            this.UserID = Convert.ToInt32(data["UserID"]);
            this.ExerciseID = Convert.ToInt32(data["ExerciseID"]);
            this.NumberSets = Convert.ToInt32(data["NumberSets"]);
            this.Amount = Convert.ToInt32(data["Amount"]);
            this.PlanDate = Convert.ToDateTime(data["PlanDate"]);
        }

        public Workout()
        {

        }
    }
}
