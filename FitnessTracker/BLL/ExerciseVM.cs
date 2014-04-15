using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ExerciseVM
    {
        public int ID { get; set; }
        public string ExerciseName { get; set; }

        public ExerciseVM(int exerciseID)
        {
            ExerciseDAO dao = new ExerciseDAO();
            Exercise exercise = dao.GetExerciseByID(exerciseID);
            this.ID = exercise.ID;
            this.ExerciseName = exercise.ExerciseName;
        }

        public ExerciseVM(Exercise exercise)
        {
            this.ID = exercise.ID;
            this.ExerciseName = exercise.ExerciseName;
        }

        public ExerciseVM()
        {

        }

    }
}
