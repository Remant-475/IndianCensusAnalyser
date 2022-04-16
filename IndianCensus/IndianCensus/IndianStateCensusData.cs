using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensus
{
    public class IndianStateCensusData
    {
        string state;
        int population;
        int area;
        int density;


        public IndianStateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);

        }
    }
}
