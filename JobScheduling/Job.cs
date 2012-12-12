using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class Job
    {
        public Job(int weight, int length)
        {
            this.Weight = weight;
            this.Length = length;
        }

        public int Weight { get; set; }
        public int Length { get; set; }
    }
}
