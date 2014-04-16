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
        public int Pounds { get; set; }
        public DateTime Date { get; set; }

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
