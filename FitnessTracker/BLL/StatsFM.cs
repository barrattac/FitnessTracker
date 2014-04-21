using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BLL
{
    public class StatsFM
    {
        public int UserID { get; set; }
        public int Weight { get; set; }
        public int PushupMax { get; set; }
        public int SitupMax { get; set; }
        public int PullupMax { get; set; }
        public DateTime Date { get; set; }

        public StatsFM()
        {
            this.Date = DateTime.Now;
        }
    }
}
