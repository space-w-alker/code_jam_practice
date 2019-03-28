using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Practice
{
    //ProblemClass loads the file and sets the value for the Number of cases(NumCases)
    //and the array of cases(Cases)
    public class ProblemClass
    {
        public int NumCases { get; set; }
        public Case[] Cases { get; set; }

        public void LoadFile(string fileName)
        {
            using (FileStream st = File.OpenRead(fileName))
            {
                StreamReader reader = new StreamReader(st);

                //read the top line and set as the number of cases
                NumCases = Int32.Parse(reader.ReadLine());

                //create an array of cases with array length equal to the number of cases
                Cases = new Case[NumCases];

                //iterate from 0 to number of cases
                for(int i = 0; i < NumCases; i++)
                {
                    //read a line and set it as the number of engines
                    int NumOfEngines = Int32.Parse(reader.ReadLine());
                    Cases[i] = new Case();
                    Cases[i].Engines = new string[NumOfEngines];

                    //read all engines.
                    for(int j = 0; j < NumOfEngines; j++)
                    {
                        Cases[i].Engines[j] = reader.ReadLine();
                    }

                    //read a line and set it as the number of queries
                    int NumOfQueries = Int32.Parse(reader.ReadLine());
                    Cases[i].Queries = new string[NumOfQueries];

                    //read all queries.
                    for(int j = 0; j < NumOfQueries; j++)
                    {
                        Cases[i].Queries[j] = reader.ReadLine();
                    }
                }
            }
        }
    }
}
