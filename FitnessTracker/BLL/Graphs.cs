using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Graphs
    {
        public Graph Weight { get; set; }
        public Graph PushupMax { get; set; }
        public Graph Workout { get; set; }

        public Graphs(Graph weight)
        {
            this.Weight = weight;
        }

        public Graphs()
        {
            this.Weight = new Graph();
        }
    }
}
