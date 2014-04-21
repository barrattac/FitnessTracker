using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Weight
    {
        public int UserID { get; set; }
        public int Pounds { get; set; }
        public DateTime Date { get; set; }

        public Weight(int userID, int weight, DateTime date)
        {
            this.UserID = userID;
            this.Pounds = weight;
            this.Date = date;
        }

        public Weight(SqlDataReader data)
        {
            this.Pounds = Convert.ToInt32(data["Weight"]);
            this.Date = Convert.ToDateTime(data["Date"]);
        }

        public Weight()
        {

        }
    }
}
