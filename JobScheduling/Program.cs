using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduling
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"jobs.txt");
            DiffJobTime(lines);
            RationJobTime(lines);
            
            Console.ReadLine();
        }

        private static void RationJobTime(string[] lines)
        {
            long sum = 0;
            int sumOfLength = 0;

            List<RatioJobTime> ratioJobs = lines.Skip(1)
                .Select(x => new RatioJobTime(Convert.ToInt32(x.Split(' ')[0]), Convert.ToInt32(x.Split(' ')[1])))
                .OrderByDescending(x => x.Ratio).ToList();

            foreach (var item in ratioJobs)
            {
                sumOfLength += item.Length;
                sum = checked(sum + item.Weight * sumOfLength);
            }

            Console.WriteLine("Schedule Job with ratio : {0}", sum);
        }

        private static void DiffJobTime(string[] lines)
        {
            long sum = 0;
            int sumOfLength = 0;
            List<DiffJob> diffJobs = lines.Skip(1)
                .Select(x => new DiffJob(Convert.ToInt32(x.Split(' ')[0]), Convert.ToInt32(x.Split(' ')[1])))
                .OrderByDescending(x => x.Difference).ThenByDescending(t => t.Weight).ToList();

            foreach (var item in diffJobs)
            {
                sumOfLength = checked(sumOfLength + item.Length);
                sum = checked(sum + item.Weight * sumOfLength);
            }

            Console.WriteLine("Schedule Job with difference : {0}", sum);
        }
    }
}
