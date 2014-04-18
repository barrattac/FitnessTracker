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
        public string Title { get; set; }
        public List<double> LeftSide { get; set; }
        public List<string> Bottom { get; set; }
        public List<string> BarHeights { get; set; }
        public List<string> BarTop { get; set; }
        public List<double> Values { get; set; }

        public Graph(List<MaxVM> maxes)
        {
            if (maxes != null && maxes.Count > 0)
            {
                this.Title = maxes[0].Name;
                double max = 0;
                for (int i = 0; i < maxes.Count && i < 10; i++)
                {
                    if (maxes[i].Amount > max)
                    {
                        max = maxes[i].Amount;
                    }
                }
                this.LeftSide = new List<double>() { 0, Math.Round(max * 0.11), Math.Round(max * 0.22), Math.Round(max * 0.33), Math.Round(max * 0.44), Math.Round(max * 0.56), Math.Round(max * 0.67), Math.Round(max * 0.78), Math.Round(max * 0.89), max };
                this.Bottom = new List<string>();
                for (int i = 0; i < maxes.Count && i < 10; i++)
                {
                    this.Bottom.Add(maxes[i].Date.ToString("MM/dd"));
                }
                this.BarHeights = new List<string>();
                this.BarTop = new List<string>();
                this.Values = new List<double>();
                for (int i = 0; i < maxes.Count && i < 10; i++)
                {
                    this.BarHeights.Add((maxes[i].Amount / max * 100).ToString() + "%");
                    this.BarTop.Add((100 - (maxes[i].Amount / max * 100)).ToString() + "%");
                    this.Values.Add(maxes[i].Amount);
                }
            }
        }

        public Graph(List<Weight> weights)
        {
            this.Title = "Weight Change";
            double maxWeight = 0;
            for (int i = 0; i < weights.Count && i < 10; i++)
            {
                if (weights[i].Pounds > maxWeight)
                {
                    maxWeight = weights[i].Pounds;
                }
            }
            this.LeftSide = new List<double>() { 0, maxWeight * 0.11, maxWeight * 0.22, maxWeight * 0.33, maxWeight * 0.44, maxWeight * 0.56, maxWeight * 0.67, maxWeight * 0.78, maxWeight * 0.89, maxWeight };
            this.Bottom = new List<string>();
            for (int i = 0; i < weights.Count && i < 10; i++)
            {
                this.Bottom.Add(weights[i].Date.ToString("MM/dd"));
            }
            this.BarHeights = new List<string>();
            this.BarTop = new List<string>();
            this.Values = new List<double>();
            for (int i = 0; i < weights.Count && i < 10; i++)
            {
                this.BarHeights.Add((weights[i].Pounds / maxWeight * 100).ToString() + "%");
                this.BarTop.Add((100 - (weights[i].Pounds / maxWeight * 100)).ToString() + "%");
                this.Values.Add(weights[i].Pounds);
            }
        }

        public Graph()
        {

        }
    }
}
