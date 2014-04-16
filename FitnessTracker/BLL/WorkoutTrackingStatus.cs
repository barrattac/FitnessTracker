using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class WorkoutTrackingStatus
    {
        public void UpdateWorkouts(List<WorkoutVM> workouts)
        {
            foreach (WorkoutVM vm in workouts)
            {
                UpdateWorkout(new WorkoutFM(vm));
            }
        }

        private void UpdateWorkout(WorkoutFM fm)
        {
            PlanningServices log = new PlanningServices();
            WorkoutDAO dao = new WorkoutDAO();
            Workout workout = new Workout();
            workout.ID = fm.ID;
            workout.Complete = fm.Complete;
            dao.MarkComplete(workout);
        }
    }
}
