using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class GoalFM
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Weight { get; set; }
        public int PushupMax { get; set; }
        public int SitupMax { get; set; }
        public int PullupMax { get; set; }
        public DateTime GoalDate { get; set; }
        public DateTime AchievedDate { get; set; }
        public bool Achieved { get; set; }

        public GoalFM()
        {
            this.GoalDate = DateTime.Now.Date;
            this.Achieved = false;
        }
    }
}
