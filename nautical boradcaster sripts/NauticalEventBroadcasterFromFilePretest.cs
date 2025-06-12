using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Data;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary>
///  Nautical data Broadcaster by Michele Fiorentino 2021 michele.fiorentino@poliba.it
/// </summary>
/// 

public class NauticalEventBroadcasterFromFilePretest : MonoBehaviour
{
    [Tooltip("File ; titled separated txt file in Asset path")]
    public string fileName = @"Assets/NauticalBroadcast/txtdata/dati 3 min V2.txt"; // default
    [Tooltip("File ; serator input file")]
    public string inputFileDelimiter = ";";
    [Tooltip("time for reading each file line in seconds ")]
    public double deltatimeMilliSeconds = 1000;
    [Tooltip("loop the data from begining")]
    public bool loop = true;
    [Tooltip("Prints Debug Fileread")]
    public bool printoutfilereading = false;
    [Tooltip("Prints Debug events")]
    public bool printoutevents = false;
    WindEventArgs mywind = new WindEventArgs();

    // Stop reading if condition is met 
    public bool pauseReading = false;

    // normally broadcast Windchange
    public bool broadcast = true;
    [Tooltip("Readonly: registered Listeners")]
    public int listeners = 0;

    [Tooltip("Readonly: current line of the input file")]
    public int currentLine = 0;


    // Pretest Specific (save files)
    [Tooltip("File extensione ; serator input file")]
    public string fileExtesionOutputFile = ".csv";

    [Tooltip("Set here the Event at keypress")]
    public UnityEvent keypressCustomEvent; // the events to be run

    // this is a counter for lastWindReading form main reading timing 
    private DateTime latestWindReadingTime;

    private DateTime latestwindTestEvent;
    // Filename
    string filepath;

    // this is the wind event handler - listerers must subscribe this
    public static event EventHandler<WindEventArgs> WindChanged;

    // private
    private DataTable datatable = new DataTable(); // This is the main table
    //private TextWriter tw ;
    // Start is called before the first frame updat
    void Start()
    {
        LoadNauticalData();
        InizializeOutputFile("wind_");
        latestWindReadingTime = DateTime.Now;
        latestwindTestEvent = DateTime.Now;


    }

    void Update()
    {
        // update number of listeners
        listeners = WindChanged.GetInvocationList().Length;

        // this is the update engine (replaces older yeld
        double delta = (DateTime.Now - latestWindReadingTime).TotalMilliseconds;
        //Debug.Log("delta " + delta);
        if (!pauseReading && delta > deltatimeMilliSeconds)

        {
            //Debug.Log("entra !blockreading &&  delta > deltatimeSeconds");
            processWindLine(currentLine++);
        }

        // this checks the user inetraction
        if ((OVRInput.GetDown(OVRInput.Button.One) ||
       OVRInput.GetDown(OVRInput.Button.Two) ||
       Input.GetKeyDown(KeyCode.A)))
        {
            // start klick event if available
            if (keypressCustomEvent != null)
            {
                keypressCustomEvent.Invoke();
            }

            if (pauseReading)
            {
                double winddelta = (DateTime.Now - latestwindTestEvent).TotalMilliseconds;
                saveOutputEntry("OK", winddelta);
                pauseReading = false;
                // read next input line
                processWindLine(currentLine++);
                Debug.Log("blockreading = false");
            }
            else {
                double winddelta = (DateTime.Now - latestwindTestEvent).TotalMilliseconds;
                saveOutputEntry("Error", winddelta);
                  }
        }
    }
    private void InizializeOutputFile(string p_title)
    {
       
        // opens file in user path 
        string userdirectory = Application.persistentDataPath + "/Risultati/";
        bool exists = Directory.Exists(userdirectory);

        if (!exists)
        {
            Debug.Log("Created directory:" + userdirectory);
            Directory.CreateDirectory(userdirectory);
        }

        //Create Filename and if it doesn't exist
        filepath = userdirectory + "Sessione_" + p_title + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + fileExtesionOutputFile;

        if (!File.Exists(filepath))
        {
            TextWriter tw = new StreamWriter(filepath, true);
            //File.WriteAllText(filepath, "ID;Status;ReactionTime[ms]\n");
            tw.WriteLine("Timestamp;windfileline;Status;ReactionTimeFromLastWindchange[ms]");
            tw.Close();
            Debug.Log("Created file log: " + filepath);
        }
    }
    void saveOutputEntry(string res, double delta )
    {
        
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string result = timestamp + ";" + currentLine + ";" + res + ";" + delta.ToString("f0");
        Debug.Log(result);
        TextWriter tw = new StreamWriter(filepath, true);
        tw.WriteLine(result);
        tw.Close();
    }



    void processWindLine(int p_line)
    {
        if (p_line > datatable.Rows.Count)
        {
            
            SceneManager.LoadScene("FinalScene");
            Debug.Log("Wind data finished");
        }
        else
        {
            // chck number p_line
            DataRow row = datatable.Rows[p_line];
            //Debug.Log("ProcessNauticalData----Row No: " + datatable.Rows.IndexOf(row));
            try
            {
                // populate Wind structure
                mywind.Speed = float.Parse(row["windspeed"].ToString());
                mywind.Angle = float.Parse(row["windangle"].ToString());
                latestWindReadingTime = DateTime.Now;
                //if (printoutevents) Debug.Log("Parsed windspeed" + float.Parse(row["windspeed"].ToString()) + " Parsed windangle " + float.Parse(row["windangle"].ToString()));
                
                // Triggers Block if certain condition happen
                if ((mywind.Angle % 10) == 0 && (mywind.Speed % 1) == 0)
                {

                    latestwindTestEvent = DateTime.Now;
                    pauseReading = true;
                    Debug.Log("Line: " + p_line+ " pauseReading = true");

                }

                //broadcast always
                OnWindChanged(mywind);
            }
            catch
            {
                if (printoutfilereading) Debug.Log("Error parsing-skipline row:" + datatable.Rows.IndexOf(row));
            }
        }
    }


    protected virtual void OnWindChanged(WindEventArgs last)
    {
        if (WindChanged != null)
        {
            if (printoutevents) Debug.Log("Broadcast: "+last.Dump());
            WindChanged(this, last);
        }
    }

    // Load data stracture in datatable form file
    void LoadNauticalData()
    {
        StreamReader streamreader = new StreamReader(fileName);
        // pupulate the header
        string[] columnheaders = streamreader.ReadLine().Split(inputFileDelimiter.ToCharArray());
        foreach (string columnheader in columnheaders)
        {
            datatable.Columns.Add(columnheader); // I've added the column headers here.
        }

        // Populate Table 
        while (streamreader.Peek() > 0) // if any
        {
            DataRow datarow = datatable.NewRow();
            datarow.ItemArray = streamreader.ReadLine().Split(inputFileDelimiter.ToCharArray());
            datatable.Rows.Add(datarow);
        }

        if (printoutfilereading) Debug.Log("Loaded Text File: " + fileName);
        // Debug 
        if (printoutfilereading)
        {
            Datainfo();
            DumpData();
        }

    }
    // printouts main datatble info
    void Datainfo()
    {
        Debug.Log("---Columns: " + datatable.Columns.Count + " Rows: " + datatable.Rows.Count);
    }
    void DumpHeader()
    {
        DumpRow(0);
    }

    // printouts row  datatable 
    void DumpRow(int index)
    {
        if (index >= 0 && index < datatable.Rows.Count)
        {
            DataRow selectedrow = datatable.Rows[index];
            Debug.Log("---row: " + index);
            foreach (DataColumn column in datatable.Columns)
            {
                /*
                //check what columns you need
                if (column.ColumnName == "Column2" ||
                    column.ColumnName == "Column12" ||
                    column.ColumnName == "Column45")
                    */
                {
                    Debug.Log(column.ColumnName + " :" + selectedrow[column]);
                }
            }
        }
    }

    // printouts all  datatable 
    void DumpData()
    {
        foreach (DataRow row in datatable.Rows)
        {
            Debug.Log("----Row No: " + datatable.Rows.IndexOf(row) + "----");

            foreach (DataColumn column in datatable.Columns)
            {
                /*
                //check what columns you need
                if (column.ColumnName == "Column2" ||
                    column.ColumnName == "Column12" ||
                    column.ColumnName == "Column45")
                    */
                {
                    Debug.Log(column.ColumnName + " " + row[column]);
                }
            }
        }
    }
}
