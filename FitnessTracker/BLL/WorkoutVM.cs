using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class WorkoutVM
    {
        public int ID { get; set; }
        public UserVM User { get; set; }
        public ExerciseVM Exercise { get; set; }
        public int NumberSets { get; set; }
        public int Amount { get; set; }
        public DateTime PlanDate { get; set; }

        public WorkoutVM(Workout workout)
        {
            this.ID = workout.ID;
            this.User = new UserVM(workout.UserID);
            this.Exercise = new ExerciseVM(workout.ExerciseID);
            this.NumberSets = workout.NumberSets;
            this.Amount = workout.Amount;
            this.PlanDate = workout.PlanDate;
        }

        public WorkoutVM()
        {

        }
    }
}
