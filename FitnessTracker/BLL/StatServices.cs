using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StatServices
    {
        public Graphs GetGraphs(int userID)
        {
            Graphs graphs = new Graphs();
            List<MaxVM> maxes = GetMaxes(userID);
            graphs.Weight = UserWeights(userID);
            graphs.PushupMax = GetPushupMaxes(maxes);
            graphs.SitupMax = GetSitupMaxes(maxes);
            graphs.PullupMax = GetPullupMaxes(maxes);
            return graphs;
        }

        private Graph GetPushupMaxes(List<MaxVM> maxes)
        {
            List<MaxVM> pushups = new List<MaxVM>();
            while (maxes != null && maxes.Count > 0 && (pushups.Count == null || pushups.Count < 10) && maxes[0].Name == "Pushup Max")
            {
                pushups.Add(maxes[0]);
                maxes.RemoveAt(0);
            }
            return new Graph(pushups);
        }

        private Graph GetSitupMaxes(List<MaxVM> maxes)
        {
            List<MaxVM> situps = new List<MaxVM>();
            while (maxes != null && maxes.Count > 0 && maxes[0].Name == "Pushup Max")
            {
                maxes.RemoveAt(0);
            }
            while (maxes != null && maxes.Count > 0 && (situps.Count == null || situps.Count < 10) && maxes[0].Name == "Situp Max")
            {
                situps.Add(maxes[0]);
                maxes.RemoveAt(0);
            }
            return new Graph(situps);
        }

        private Graph GetPullupMaxes(List<MaxVM> maxes)
        {
            List<MaxVM> pullups = new List<MaxVM>();
            while (maxes != null && maxes.Count > 0 && maxes[0].Name != "Pullup Max")
            {
                maxes.RemoveAt(0);
            }
            while (maxes != null && maxes.Count > 0 && (pullups.Count == null || pullups.Count < 10))
            {
                pullups.Add(maxes[0]);
                maxes.RemoveAt(0);
            }
            return new Graph(pullups);
        }

        private Graph UserWeights(int userID)
        {
            WeightDAO dao = new WeightDAO();
            return new Graph(dao.GetUserWeights(userID));
        }

        private List<WeightVM> ConvertWeights(List<Weight> list)
        {
            List<WeightVM> weights = new List<WeightVM>();
            for (int i = 0; i < list.Count; i++)
            {
                weights.Add(new WeightVM(list[i]));
            }
            return weights;
        }

        private List<MaxVM> GetMaxes(int userID)
        {
            MaxDAO dao = new MaxDAO();
            List<Max> maxes = dao.GetUserMaxes(userID);
            List<MaxVM> vm = new List<MaxVM>();
            for (int i = 0; i < maxes.Count; i++)
            {
                vm.Add(new MaxVM(maxes[i]));
            }
            return vm;
        }

        public bool UpdeteWeight(StatsFM fm)
        {
            MaxDAO dao = new MaxDAO();
            fm.Weight = dao.UpdateWeight(new Weight(fm.UserID, fm.Weight, fm.Date));
            int success = dao.UpdateStats(new Max(fm.UserID, fm.Weight, fm.Date), "weight");
            return (success > 0);
        }

        public bool UpdetePushupMax(StatsFM fm)
        {
            MaxDAO dao = new MaxDAO();
            fm.Weight = dao.UpdatePushupMax(ConvertStats(fm));
            int success = dao.UpdateStats(new Max(fm.UserID, fm.Weight, fm.Date), "pushup");
            return (success > 0);
        }

        public bool UpdeteSitupMax(StatsFM fm)
        {
            MaxDAO dao = new MaxDAO();
            fm.Weight = dao.UpdateSitupMax(ConvertStats(fm));
            int success = dao.UpdateStats(new Max(fm.UserID, fm.Weight, fm.Date), "situp");
            return (success > 0);
        }

        public bool UpdetePullupMax(StatsFM fm)
        {
            MaxDAO dao = new MaxDAO();
            fm.Weight = dao.UpdatePullupMax(ConvertStats(fm));
            int success = dao.UpdateStats(new Max(fm.UserID, fm.Weight, fm.Date), "pullup");
            return (success > 0);
        }

        private Max ConvertStats(StatsFM fm)
        {
            int number = fm.PushupMax;
            if (fm.SitupMax > number)
            {
                number = fm.SitupMax;
            }
            else if (fm.PullupMax > number)
            {
                number = fm.PullupMax;
            }
            return new Max(fm.UserID, number, fm.Date);
        }
    }
}
