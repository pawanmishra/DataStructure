using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class RatioJobTime : Job
    {
        public RatioJobTime(int weight, int length) : base(weight, length) 
        {
            Ratio = (float)weight / (float)length;
        }

        public float Ratio { get; set; }
    }
}
