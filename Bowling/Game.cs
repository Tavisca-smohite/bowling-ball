using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        public List<int> FlagsForFrame = new List<int>();
        public List<List<int>> TrackOfThrows = new List<List<int>>();
        List<int> throwsPerFrame = new List<int>();
        
        public void Roll(int pins)
        {
            MaintainScorePerFrame(pins);

           
        }

        public int GetScore()
        {
            int FinalScore = GetCurrentScore();
            
            return FinalScore;
        }
        public int GetCurrentScore()
        {
            int result = 0;
            for (int i = 0; i < TrackOfThrows.Count && i < 10; i++)
            {
                
                if (FlagsForFrame[i] == 2)
                {
                    result += TrackOfThrows[i][0];
                    if (i + 1 < TrackOfThrows.Count && FlagsForFrame[i + 1] < 2)
                    {
                        for (int k = 0; k < TrackOfThrows[i + 1].Count; k++)
                        {
                            result += TrackOfThrows[i + 1][k];
                        }
                       

                    }
                    else if (i + 1 < TrackOfThrows.Count && FlagsForFrame[i + 1] == 2)
                    {
                        result += TrackOfThrows[i + 1][0];
                        if (i + 2 < TrackOfThrows.Count)
                        {
                            result += TrackOfThrows[i + 2][0];
                        }
                        
                    }
                }
                else if (FlagsForFrame[i] == 1)
                {
                    for (int k = 0; k < TrackOfThrows[i].Count; k++)
                    {
                        result += TrackOfThrows[i][k];
                    }
                    if (i + 1 < TrackOfThrows.Count)
                    {
                        result += TrackOfThrows[i + 1][0];
                    }
                   
                }
                else if (FlagsForFrame[i] == 0)
                {
                    for (int k = 0; k < TrackOfThrows[i].Count; k++)
                    {
                        result += TrackOfThrows[i][k];
                    }
                }


               


            }

            return result;
        }

        public void MaintainScorePerFrame(int pins)
        {

            
            if (throwsPerFrame.Count < 2)
            {
                if (throwsPerFrame.Count == 0)
                {
                    
                    throwsPerFrame.Add(pins);
                    if (pins == 10)
                    {
                        FlagsForFrame.Add(2);

                        var temp = new List<int>();
                        foreach (var item in throwsPerFrame)
                            temp.Add(item);
                        TrackOfThrows.Add(temp);

                        throwsPerFrame.Clear();
                    }
                    else
                    {
                        FlagsForFrame.Add(0);
                        TrackOfThrows.Add(throwsPerFrame);
                    }
                }
                else if (throwsPerFrame.Count == 1)
                {
                    throwsPerFrame.Add(pins);
                    int result = throwsPerFrame.Aggregate((a, b) => b + a);
                    if (result == 10)
                    {
                        FlagsForFrame[FlagsForFrame.Count - 1] = 1; //spare

                    }
                    
                    var temp = new List<int>();
                    foreach (var item in throwsPerFrame)
                        temp.Add(item);
                    TrackOfThrows[TrackOfThrows.Count - 1] = temp;
                    throwsPerFrame.Clear();
                }
            }
            else
            {
                throwsPerFrame.Clear();
            }


        }


    }

}

