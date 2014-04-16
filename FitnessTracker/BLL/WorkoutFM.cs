using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class WorkoutFM
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<ExerciseFM> Exercises { get; set; }
        public string Exercise { get; set; }
        public string NewExercise { get; set; }
        public int NumberSets { get; set; }
        public int Amount { get; set; }
        public DateTime PlanDate { get; set; }
        public bool ReoccurringDaily { get; set; }
        public bool ReoccurringWeekly { get; set; }
        public int NumberReoccurring { get; set; }
        public bool Complete { get; set; }

        public WorkoutFM(WorkoutVM vm)
        {
            this.ID = vm.ID;
            this.Complete = vm.Complete;
        }

        public WorkoutFM(int userID, DateTime date)
        {
            ExerciseDAO dao = new ExerciseDAO();
            this.UserID = userID;
            this.PlanDate = date;
            List<Exercise> exercise = dao.GetExercises();
            this.Exercises = new List<ExerciseFM>();
            for(int i = 0; i < exercise.Count; i++)
            {
                if (exercise[i] != null)
                {
                    this.Exercises.Add(new ExerciseFM(exercise[i]));
                }
            }
            this.Complete = false;
        }

        public WorkoutFM()
        {

        }

    }
}