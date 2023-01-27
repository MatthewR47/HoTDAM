using FlyKnockdown.Model;

namespace FlyKnockdown.Controller
{
    internal class FileController
    {
        public List<ActivityMonitor> loadFiles()
        {
            List <ActivityMonitor> monitorList = new List<ActivityMonitor>();

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.Multiselect = true;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in fileDialog.FileNames)
                    {
                        ActivityMonitor monitor = new ActivityMonitor(file);
                        monitorList.Add(monitor);
                    }
                }
            }
            return monitorList;
        }
    }
}
