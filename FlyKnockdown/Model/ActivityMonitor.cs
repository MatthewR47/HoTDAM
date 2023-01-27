
namespace FlyKnockdown.Model
{
    internal class ActivityMonitor
    {
        private string fileName;
        private string[] cells;

        public ActivityMonitor(string name)
        {
            this.fileName = name;
            cells = new string[32];
        }

        public void setGroup(int cellIndex, string groupName)
        {
            cells[cellIndex] = groupName;
        }

        public string getGroup(int cellIndex)
        {
            return cells[cellIndex];
        }

        public override string ToString()
        {
            return fileName.Substring(fileName.LastIndexOf("\\") + 1);
        }
    }
}
