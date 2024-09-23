using FlyKnockdown.Model;
using FlyKnockdown.View;
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
                    // Instantiate a monitor object for each
                    // of the exported monitor files.
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
                        string[,] dataGridInformation = new string[33, timeStamps.GetLength(0)];
                        for (int i = 0; i < timeStamps.GetLength(0); i++)
                        {
                            dataGridInformation[0, i] = timeStamps[i, 1];
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            for (int j = 0; j < timeStamps.GetLength(0); j++)
                            {
                                dataGridInformation[i + 1, j] = flies[i].getMovement()[j];
                            }
                        }

                        for (int i = 0; i < timeStamps.GetLength(0); i++)
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

        public static void exportKnockdownData(List<ActivityMonitor> monitors, string defaultName)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.RestoreDirectory = true;
                fileDialog.FileName = defaultName + ".csv";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputText = "";
                    foreach (ActivityMonitor currentMonitor in monitors)
                    {
                        Fly[] flies = currentMonitor.getFlies();
                        Dictionary<string, List<int>> groupedKnockdownData = new Dictionary<string, List<int>>();

                        HashSet<string> groups = new HashSet<string>();

                        // Prepare the groups
                        foreach (Fly fly in flies)
                        {
                            groups.Add(fly.getGroupName());
                        }

                        string[,] outputMatrix = new string[33, groups.Count];

                        int count = 0;
                        foreach (string group in groups)
                        {
                            outputMatrix[0,count] = group;
                            int bottomIndex = 0;
                            for (int i = 0; i < flies.Length; i++)
                            {
                                if (flies[i].getGroupName().Equals(group))
                                {
                                    bottomIndex++;
                                    outputMatrix[bottomIndex, count] = flies[i].getTimeAlive().ToString();
                                }
                            }
                            count++;
                        }

                        // Build the output text
                        outputText += currentMonitor.ToString() + "\n";

                        for (int i = 0; i < 33; i++)
                        {
                            for (int j = 0; j < groups.Count; j++)
                            {
                                try
                                {
                                    outputText += outputMatrix[i,j] + ",";
                                } catch (Exception)
                                {
                                    
                                }
                            }
                            outputText = outputText.Substring(0, outputText.Length - 1);
                            outputText += "\n";
                        }
                       
                        outputText += "\n";
                    }
                    File.WriteAllText(fileDialog.FileName, outputText);
                }
            }
        }

        public static void exportKnockdownData(ActivityMonitor inMonitor)
        {
            List<ActivityMonitor> monitor = new List<ActivityMonitor>();
            monitor.Add(inMonitor);
            exportKnockdownData(monitor, Path.ChangeExtension(inMonitor.ToString(), null) + "_Knockdown");
        }
    }
}
