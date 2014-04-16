using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class WeightVM
    {
        public int Pounds { get; set; }
        public DateTime Date { get; set; }

        public WeightVM(Weight weight)
        {
            this.Pounds = weight.Pounds;
            this.Date = weight.Date;
        }

        public WeightVM()
        {

        }
    }
}
