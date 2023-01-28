namespace FlyKnockdown.Model
{
    internal class ActivityMonitor
    {
        private string fileName;
        private Fly[] flies;
        private string[,] timeInterval;

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
            timeInterval = new string[302,2];
            string[] lines = File.ReadAllLines(@fileName);
            for (int i = 0; i < 302; i++)
            {
                string[] lineElements = lines[i].Split("\t");
                timeInterval[i,0] = lineElements[2];
                timeInterval[i, 1] = lineElements[3];
            }
        }

        public void assignFlies()
        {
            flies = new Fly[32];

            for (int i = 0; i < 32; i++)
            {
                string[] lines = File.ReadAllLines(@fileName);
                string[] flyMovement = new string[302];

                for (int j = 0; j < 302; j++)
                {
                    string[] lineElements = lines[i].Split("\t");
                    flyMovement[j] = lineElements[i + 10];
                }

                flies[i] = new Fly(flyMovement);
            }
        }

    }
}
