using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Practice
{
    class Program
    {
        //main function that brings it all together and writes the solution to a file.
        static void Main(string[] args)
        {
            ProblemClass prob = new ProblemClass();
            prob.LoadFile("A-large-practice.in");
            string ans = Solution1.ParseSolutions(prob.Cases);
            FileStream st = File.Open("output_large.out", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(st);
            writer.Write(ans);
            writer.Close();
            Console.WriteLine("This is Written");
        }
    }
}
