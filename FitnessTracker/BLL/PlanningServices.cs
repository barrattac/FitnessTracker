using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PlanningServices
    {
        public List<List<WorkoutVM>> GetWorkoutPlan(int userID)
        {
            List<List<WorkoutVM>> workouts = new List<List<WorkoutVM>>();
            List<DateTime> dates = GetCalendar();
            for (int i = 0; i < 35; i++)
            {
                List<WorkoutVM> workout = GetWorkoutPlan(userID, dates[i].Date);
                if (workout == null || workout.Count == 0)
                {
                    WorkoutVM vm = new WorkoutVM();
                    vm.PlanDate = dates[i].Date;
                    workout.Add(vm);
                }
                workouts.Add(workout);
            }
            return workouts;
        }

        public List<WorkoutVM> GetWorkoutPlan(int userID, DateTime date)
        {
            WorkoutDAO dao = new WorkoutDAO();
            List<WorkoutVM> vm = new List<WorkoutVM>();
            List<Workout> workouts = dao.GetWorkouts(userID, date);
            if (workouts != null)
            {
                for (int i = 0; i < workouts.Count; i++)
                {
                    vm.Add(new WorkoutVM(workouts[i]));
                }
            }
            else
            {
                WorkoutVM workout = new WorkoutVM();
                workout.PlanDate = date;
                vm.Add(workout);
            }
            return vm;
        }

        private List<DateTime> GetCalendar()
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime sun = GetFirstDay();
            for (int i = 0; i < 35; i++)
            {
                dates.Add(sun.AddDays(i));
            }
            return dates;
        }

        private DateTime GetFirstDay()
        {
            DateTime sun = DateTime.Now;
            sun = sun.AddDays(-Convert.ToInt32(sun.DayOfWeek));
            while (sun.Month == DateTime.Now.Month && sun.Day != 1)
            {
                sun = sun.AddDays(-7);
            }
            return sun;
        }
    }
}
