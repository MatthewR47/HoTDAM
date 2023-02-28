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
            timeIntervals = new string[302,2];
            string[] lines = File.ReadAllLines(@fileName);
            for (int i = 0; i < 302; i++)
            {
                string[] lineElements = lines[i].Split("\t");
                timeIntervals[i,0] = lineElements[1];
                timeIntervals[i, 1] = lineElements[2];
            }
        }

        public void assignFlies()
        {
            flies = new Fly[32];
            string[] lines = File.ReadAllLines(@fileName);

            for (int i = 0; i < 32; i++)
            {
                string[] flyMovement = new string[302];

                for (int j = 0; j < 302; j++)
                {
                    string[] lineElements = lines[j].Split("\t");
                    flyMovement[j] = lineElements[i + 10];
                }

                flies[i] = new Fly(flyMovement);
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
