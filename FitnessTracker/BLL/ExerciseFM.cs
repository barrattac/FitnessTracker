using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ExerciseFM
    {
        public int ID { get; set; }
        public string ExerciseName { get; set; }

        public ExerciseFM(int id, string name)
        {
            this.ID = id;
            this.ExerciseName = name;
        }

        public ExerciseFM(Exercise exercise)
        {
            this.ID = exercise.ID;
            this.ExerciseName = exercise.ExerciseName;
        }

        public ExerciseFM()
        {

        }

    }
}
