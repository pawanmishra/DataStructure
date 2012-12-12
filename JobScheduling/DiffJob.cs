using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class DiffJob : Job, IComparable<DiffJob>
    {
        public DiffJob(int weight, int length) : base(weight, length) 
        {
            Difference = weight - length;
        }
        
        public int Difference { get; set; }

        public int CompareTo(DiffJob other)
        {
            if (this.Difference > other.Difference)
                return -1;
            else if (this.Difference < other.Difference)
                return 1;
            else
            {
                if (this.Weight > other.Weight)
                    return -1;
                else
                    return 1;
            }
        }
    }
}
