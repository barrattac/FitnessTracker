using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PlanningServices
    {
        public DateTime GetFirstDay()
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
