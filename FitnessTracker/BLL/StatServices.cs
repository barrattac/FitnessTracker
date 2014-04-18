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
        public Graph UserWeights(int userID)
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
    }
}
