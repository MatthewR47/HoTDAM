# Welcome to HoTDAM! 

Heat Tolerance assessment utilizing the Drosophila Activity Monitors (DAM2) from TriKinetics

This software has two primary functions. The first is to provide the last time of movement (i.e., time of physiological collapse or “knock down”) during an elevated temperature exposure or heat shock. The other is to rearrange the raw DAMSystem data file to facilitate activity analysis.

For correspondence or with questions, please contact Dr. Kim Carlson at carlsonka1@unk.edu

## HoTDAM! instructions for use

Instructions for use of the DAM2 system and software can be found at https://trikinetics.com/

Prior to importing your raw DAMSystem software data files into HoTDAM!, prepare them for analysis using the DAMFileScan software from TriKinetics (https://trikinetics.com/). 

At this step, the DAMFileScan software can be used to truncate the data files to make analysis of your data easier if your heat shock exposure was part of a longer monitoring session. For example, if you monitored activity for some time prior to heat shock but want to know the time to knockdown (TKD) from the moment of temperature increase, you will need to truncate the data file. To do this, scan the file using the DAMFileScan software. The software will recognize metadata, such as bin length and timestamps. Use the “First Bin to Save” and “Last Bin to Save” section to save only the desired portion of the activity data file. In the example introduced above, you would select the timestamp that corresponds to the start of the heat shock as the “First Bin to Save.” If monitoring was stopped after the heat shock, then you can leave the “Last bin to Save” as the default, which is the last timestamp in the file. If you did monitor activity for some time after the heat shock (for example, if you wanted to see if and when flies recovered from the physiological collapse as a survival phenotype), then you could make the “Last Bin to Save” the timestamp corresponding to the end of the heat shock.

After making any adjustments to the length of the data file as just described, save the scanned data file.

At this point, the scanned DAM2 data files can be imported into the HoTDAM! software (File>Load Monitor Data).

Once imported, the files can now be seen within “Monitor Data” section. If multiple monitor data files were imported, you can switch between these in the “Monitor Select” section.

The cell numbers in the “Group Designation” section correspond to the numbers associated with the cells in the DAM2 monitors. To designate experimental groups, you can click on any individual cell to edit group names. Alternatively, you can use the mult-select group definition tool.

Once experimental groups have been designated, you can export the TKD data (File>Export Knockdown Data) or the activity data for the duration of the heat shock (File>Export Activity Data).

The HoTDAM! software will export the TKD and activity data as an Excel file. 

At this point, you are ready to analyze your rearranged TKD or activity data with a statistics software!

Thank you for using HoTDAM! from the Carlson Lab at the University of Nebraska at Kearney. 

Source code is available at https://github.com/MatthewR47/HoTDAM
