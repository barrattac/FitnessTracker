using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class MaxVM
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public MaxVM(Max max)
        {
            this.Name = max.Name;
            this.Amount = max.Amount;
            this.Date = max.Date;
        }

        public MaxVM()
        {

        }
    }
}
