using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Goal
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

        public Goal(SqlDataReader data)
        {
            this.ID = Convert.ToInt32(data["ID"]);
            this.UserID = Convert.ToInt32(data["UserID"]);
            this.Weight = Convert.ToInt32(data["Weight"]);
            this.PushupMax = Convert.ToInt32(data["PushupMax"]);
            this.SitupMax = Convert.ToInt32(data["SitupMax"]);
            this.PullupMax = Convert.ToInt32(data["PullupMax"]);
            this.GoalDate = Convert.ToDateTime(data["Date"]);
            try
            {
                this.AchievedDate = Convert.ToDateTime(data["AchievedDate"]);
                this.Achieved = Convert.ToBoolean(data["Achieved"]);
            }
            catch
            {
                this.AchievedDate = new DateTime();
                this.Achieved = false;
            }
        }

        public Goal()
        {
            this.GoalDate = DateTime.Now.Date;
            this.Achieved = false;
        }
    }
}
