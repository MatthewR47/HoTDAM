using FlyKnockdown.Model;
using System.Windows.Forms;

namespace FlyKnockdown.Controller
{
    internal static class FileController
    {
        public static List<ActivityMonitor> loadFiles()
        {
            List <ActivityMonitor> monitorList = new List<ActivityMonitor>();

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
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

        public static void exportActivityData(List<ActivityMonitor> monitors, string defaultName)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;
                fileDialog.FileName = defaultName + ".csv";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputText = "";
                    foreach (ActivityMonitor currentMonitor in monitors)
                    {
                        Fly[] flies = currentMonitor.getFlies();

                        // Add the labels
                        outputText += currentMonitor.ToString() + "\n";

                        outputText += "Timestamp";
                        for (int i = 0; i < 32; i++)
                        {
                            outputText += ",";
                            if (!flies[i].getGroupName().Equals("") && !(flies[i].getGroupName() == null))
                            {
                                outputText += "Fly " + (i+1) + " - " + flies[i].getGroupName();
                            }
                            else
                            {
                                outputText += "Fly " + (i+1);
                            }
                        }
                        outputText += "\n";

                        // Add the actual data
                        string[,] timeStamps = currentMonitor.getTimeInterval();
                        string[,] dataGridInformation = new string[33, 302];
                        for (int i = 0; i < 302; i++)
                        {
                            dataGridInformation[0, i] = timeStamps[i, 1];
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            for (int j = 0; j < 302; j++)
                            {
                                dataGridInformation[i + 1, j] = flies[i].getMovement()[j];
                            }
                        }

                        for (int i = 0; i < 302; i++)
                        {
                            for (int j = 0; j < 33; j++)
                            {
                                outputText += dataGridInformation[j, i] + ",";
                            }
                            outputText.Remove(outputText.Length - 1, 1);
                            outputText += "\n";
                        }
                        outputText += "\n";
                    }
                    File.WriteAllText(fileDialog.FileName, outputText);
                }
            }
        }

        public static void exportActivityData(ActivityMonitor inMonitor)
        {
            List<ActivityMonitor> monitor = new List<ActivityMonitor>();
            monitor.Add(inMonitor);
            exportActivityData(monitor, Path.ChangeExtension(inMonitor.ToString(), null) + "_Activity");
        }

        public static void exportKnockdownData(List<ActivityMonitor> monitors)
        {
            foreach (ActivityMonitor currentMonitor in monitors)
            {

            }
        }

        public static void exportKnockdownData(ActivityMonitor inMonitor)
        {
            List<ActivityMonitor> monitor = new List<ActivityMonitor>();
            monitor.Add(inMonitor);
            exportKnockdownData(monitor);
        }
    }
}
