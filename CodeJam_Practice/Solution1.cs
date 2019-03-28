using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Practice
{
    //the solution class provides funtions that help solve the problem
    public static class Solution1
    {
        public static string ParseSolutions(Case[] cases)
        {
            string[] sols = new string[cases.Length];
            for (int i = 0; i < cases.Length; i++)
            {
                sols[i] = GetSolution(cases[i], i);
            }
            return String.Join("\n", sols);
        }

        //this function takes a single string and outputs a well formatted output string
        public static string GetSolution(Case case_one, int caseNumber)
        {
            int indexAt = 0;
            int numOfSwitches = 0;

            //compute how far the index can move before having to switch
            indexAt = CountBeforeSwitch(case_one, indexAt - 1);

            //if the index is equal to the length of the array of queries, were done
            //and we can return the numOfSwitches
            while (indexAt != case_one.Queries.Length)
            {
                //if not, we again see how far the index can move before having to switch
                indexAt = CountBeforeSwitch(case_one, indexAt);
                //increase the number of times we've switched.
                numOfSwitches++;
            }
            return String.Format("Case #{0}: {1}", caseNumber+1, numOfSwitches);
        }

        //this function returns the highest number queries it can look through before having to switch.
        public static int CountBeforeSwitch(Case case_one, int start_index)
        {
            int max_index = 0;

            //iterate through each engine and compute the index at which they first appear
            foreach(string engine in case_one.Engines)
            {
                int count = FirstAppear(engine, case_one.Queries, start_index);
                if (count == case_one.Queries.Length) return count;

                //simply chose the index with the highest value, hence the "greedy" in its name
                if (count > max_index) max_index = count;
            }
            return max_index;
        }

        //this function computes the number of indexes to move before the appearance of an engine in the array of queries, given a starting index
        //the function is used by the CountBeforeSwitch function.
        public static int FirstAppear(string engine, string[] queries, int start_index)
        {
            int i = start_index;
            if (start_index == -1) i = 0;
            while (true)
            {
                if (i == queries.Length) return i;
                if(queries[i] == engine)
                {
                    return i;
                }
                i++;
            }
        }
    }
}
