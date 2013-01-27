//Recursive Concept Finder - Mark Olschesky, Moxe Health
//Adapted from the SnAPI svc pack
//Email mark@moxehealth.com for questions
//Copyright (c) 2013 Moxe Health Corporation

/*Permission is hereby granted, free of charge, to any person obtaining a copy of this software
 *and associated documentation files (the "Software"), to deal in the Software without restriction, 
 *including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 *and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
 *subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnAPIService_Client_Example.SnAPIService;

namespace SnAPIService_Client_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                     Console.WriteLine("Enter a concept ID:");
                     int concept;
                     bool result = int.TryParse(Console.ReadLine(), out concept);
                     long number = (long)concept;
                     children(number);
              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("\nPress Enter to exit program.");
            Console.ReadLine();
        }

        public static void children(long concept)
        {
            
                string guid = "GUID"; //Enter your GUID here.
                int relationship = 116680003; //The SNOMED relationship for "IS A". See SNOMED documentation for more details.
                using (SnApiServiceClient client = new SnApiServiceClient())
                {
                    
                        foreach (var item in client.GetNeighbours(concept, "0", relationship, guid))
                        {

                            if (item.PorCHorS == "C") //Don't recount parent concepts, only grab children.
                            {
                            Console.WriteLine(item.NeighbourConceptId.ToString() + "," + item.NeighbourFSN);
                            children(item.NeighbourConceptId); //Recall children recursively
                            }
                        }
                    
                    
                }
            }
            
        }


    }
}

