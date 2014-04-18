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
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public Max(SqlDataReader data, string type)
        {
            switch (type)
            {
                case "Pushup Max":
                    this.Name = "Pushup Max";
                    this.Amount = Convert.ToInt32(data["PushUpMax"]);
                    break;
                case "Situp Max":
                    this.Name = "Situp Max";
                    this.Amount = Convert.ToInt32(data["SitUpMax"]);
                    break;
                case "Pullup Max":
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
