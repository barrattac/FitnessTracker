using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Graph
    {
        public int Columns { get; set; }
        public string Title { get; set; }
        public List<double> LeftSide { get; set; }
        public List<string> Bottom { get; set; }
        public List<string> BarHeights { get; set; }
        public List<string> BarTop { get; set; }

        public Graph(List<Weight> weights)
        {
            while (weights.Count > 9)
            {
                weights.RemoveAt(0);
            }
            this.Columns = weights.Count + 1;
            this.Title = "Weight Change";
            double maxWeight = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                if (weights[i].Pounds > maxWeight)
                {
                    maxWeight = weights[i].Pounds;
                }
            }
            this.LeftSide = new List<double>() {0, maxWeight * 0.11, maxWeight * 0.22, maxWeight * 0.33, maxWeight * 0.44, maxWeight * 0.56, maxWeight * 0.67, maxWeight * 0.78, maxWeight * 0.89, maxWeight };
            this.Bottom = new List<string>();
            for (int i = 0; i < weights.Count; i++)
            {
                this.Bottom.Add(weights[i].Date.ToString("MM/dd"));
            }
            this.BarHeights = new List<string>();
            this.BarTop = new List<string>();
            for (int i = 0; i < weights.Count; i++)
            {
                this.BarHeights.Add((weights[i].Pounds/maxWeight*100).ToString() + "%");
                this.BarTop.Add((100 - (weights[i].Pounds / maxWeight * 100)).ToString() + "%");
            }
        }

        public Graph()
        {

        }
    }
}
