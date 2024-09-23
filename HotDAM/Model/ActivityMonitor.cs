using FlyKnockdown.Controller;
using FlyKnockdown.View;
namespace FlyKnockdown.Model
{
    internal class ActivityMonitor
    {
        private string fileName;
        private Fly[] flies;
        private string[,] timeIntervals;

        public ActivityMonitor(string name)
        {
            this.fileName = name;
            assignTimeInterval();
            assignFlies();
        }

        public void setGroup(int cellIndex, string groupName)
        {
            flies[cellIndex].setGroupName(groupName);
        }

        public string getGroup(int cellIndex)
        {
            return flies[cellIndex].getGroupName();
        }

        public override string ToString()
        {
            return fileName.Substring(fileName.LastIndexOf("\\") + 1);
        }

        public void assignTimeInterval()
        {
            
            string[] lines = File.ReadAllLines(@fileName);
            timeIntervals = new string[lines.Length, 2];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineElements = lines[i].Split("\t");
                timeIntervals[i,0] = lineElements[1];
                timeIntervals[i, 1] = lineElements[2];
            }
        }

        /**
         * This method adds all of the flys present that would be part 
         * of a monitor output file tto a monitor object.
         */
        public void assignFlies()
        {
            flies = new Fly[32];
            string[] lines = File.ReadAllLines(@fileName);

            for (int i = 0; i < 32; i++)
            {
                string[] flyMovement = new string[lines.Length];

                for (int j = 0; j < lines.Length; j++)
                {
                    string[] lineElements = lines[j].Split("\t");
                    flyMovement[j] = lineElements[i + 10];
                }

                flies[i] = new Fly(flyMovement);
                flies[i].setGroupName("Fly " + (i+1));
                AnalysisController.assignKnockdown(flies[i], timeIntervals);
            }
        }

        public Fly[] getFlies()
        {
            return flies;
        }

        public string[,] getTimeInterval()
        {
            return timeIntervals;
        }

    }
}
