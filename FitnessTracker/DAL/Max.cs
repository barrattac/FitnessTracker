using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Max
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public Max(int userID, int number, DateTime date)
        {
            this.UserID = userID;
            this.Amount = number;
            this.Date = date;
        }

        public Max(SqlDataReader data, string type)
        {
            switch (type)
            {
                case "Pushups":
                    this.Name = "Pushup Max";
                    this.Amount = Convert.ToInt32(data["PushUpMax"]);
                    break;
                case "Situps":
                    this.Name = "Situp Max";
                    this.Amount = Convert.ToInt32(data["SitUpMax"]);
                    break;
                case "Pullups":
                    this.Name = "Pullup Max";
                    this.Amount = Convert.ToInt32(data["PullUpMax"]);
                    break;
            }
            this.Date = Convert.ToDateTime(data["Date"]);
        }

        public Max()
        {

        }
    }
}