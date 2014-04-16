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
            List<DateTime> dates = GetCalendar(DateTime.Now);
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

        public List<List<WorkoutVM>> GetWorkoutPlans(int userID, DateTime date)
        {
            List<List<WorkoutVM>> workouts = new List<List<WorkoutVM>>();
            List<DateTime> dates = GetCalendar(date);
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
            if (workouts != null && workouts.Count > 0)
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

        private List<DateTime> GetCalendar(DateTime date)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime sun = GetFirstDay(date);
            for (int i = 0; i < 35; i++)
            {
                dates.Add(sun.AddDays(i));
            }
            return dates;
        }

        private DateTime GetFirstDay(DateTime date)
        {
            DateTime sun = date;
            sun = sun.AddDays(-Convert.ToInt32(sun.DayOfWeek));
            while (sun.Month == date.Month && sun.Day != 1)
            {
                sun = sun.AddDays(-7);
            }
            return sun;
        }

        public void AddWorkout(WorkoutFM fm)
        {
            WorkoutDAO dao = new WorkoutDAO();
            Workout workout = ConvertWorkout(fm);
            dao.AddWorkout(workout);
            if (fm.ReoccurringWeekly)
            {
                int re = fm.NumberReoccurring;
                while (re > 0)
                {
                    workout.PlanDate = workout.PlanDate.AddDays(7);
                    dao.AddWorkout(workout);
                    re--;
                }
                fm.ReoccurringWeekly = false;
                workout.PlanDate = fm.PlanDate;
            }
            while (fm.NumberReoccurring > 0 && fm.ReoccurringDaily)
            {
                workout.PlanDate = workout.PlanDate.AddDays(1);
                dao.AddWorkout(workout);
                fm.NumberReoccurring--;
            }
        }

        internal Workout ConvertWorkout(WorkoutFM fm)
        {
            Workout workout = new Workout();
            workout.ID = fm.ID;
            workout.ExerciseID = GetWorkoutID(fm);
            workout.UserID = fm.UserID;
            workout.Amount = fm.Amount;
            workout.NumberSets = fm.NumberSets;
            workout.PlanDate = fm.PlanDate;
            return workout;
        }

        private int GetWorkoutID(WorkoutFM fm)
        {
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(fm.Exercise);
            }
            catch
            {
                ID = GetExerciseIDByName(fm.NewExercise);
            }
            return ID;
        }

        private int GetExerciseIDByName(string name)
        {
            ExerciseDAO dao = new ExerciseDAO();
            foreach(Exercise exercise in dao.GetExercises())
            {
                if (exercise.ExerciseName == name)
                {
                    return exercise.ID;
                }
            }
            return dao.AddExercise(name);
        }

        public void DeleteWorkout(int workoutID)
        {
            WorkoutDAO dao = new WorkoutDAO();
            dao.DeleteWorkout(workoutID);
        }
    }
}