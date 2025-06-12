using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Data;
using System;

/// <summary>
///  Nautical data Broadcaster by Michele Fiorentino 2021 michele.fiorentino@poliba.it
/// </summary>
public class NauticalEventBroadcasterFromFile : MonoBehaviour
{
    [Tooltip("File ; titled separated txt file in Asset path")]
    public string fileName = @"Assets/NauticalBroadcast/txtdata/wind_speedevo.txt"; // default
    [Tooltip("File ; separated txt file  da cercare in Asset path")]
    public string delimiter = ";";
    [Tooltip("time for reading each file line in seconds ")]
    public float deltatime = 5.0f;
    [Tooltip("loop the data from begining")]
    public bool loop = true;
    [Tooltip("Prints Debug Fileread")]
    public bool printoutfilereading = false;
    [Tooltip("Prints Debug events")]
    public bool printoutevents = false;
    
    // this is the wind event handler - listerers must subscribe this
     public static event EventHandler<WindEventArgs> WindChanged;
    
    // private
    private DataTable datatable = new DataTable(); // This is the main table

    // Start is called before the first frame updat
    void Start()
    {
        // myFilePath = Application.dataPath + "/" + fileName;
        LoadNauticalData();
        StartCoroutine(ProcessNauticalData());
    }


    /// This is teh main routine that do the broadcast
    IEnumerator ProcessNauticalData()
    {
        while (loop)
        {
            foreach (DataRow row in datatable.Rows)
            {
                //if (datatable.Rows.IndexOf(row) != 0) // skip first containing header (check if necessary)
                { // remove thi one day
                    //Debug.Log("ProcessNauticalData----Row No: " + datatable.Rows.IndexOf(row));
                    WindEventArgs mywind = new WindEventArgs();
                   
                    try
                    {
                        // populate Wind structure
                        mywind.Speed = float.Parse(row["windspeed"].ToString());
                        mywind.Angle = float.Parse(row["windangle"].ToString());
                        if (printoutevents) Debug.Log("Parsed windspeed" + float.Parse(row["windspeed"].ToString()) + " Parsed windangle " + float.Parse(row["windangle"].ToString()));
                        OnWindChanged(mywind);
                    }
                    catch {
                        if (printoutfilereading) Debug.Log("Error parsing-skipline row:"+ datatable.Rows.IndexOf(row));
                    }
                } // remove thi one day
                yield return new WaitForSeconds(deltatime);
            }
            //print("end loop");
        }
    }

    protected virtual void OnWindChanged(WindEventArgs last)
    {
        if (WindChanged != null)
        {
            if (printoutevents) Debug.Log(last.Dump());
            WindChanged(this, last);
 
        }
    }

    // Load data stracture in datatable form file
    void LoadNauticalData()
    {
        StreamReader streamreader = new StreamReader(fileName);
        // pupulate the header
        string[] columnheaders = streamreader.ReadLine().Split(delimiter.ToCharArray());
        foreach (string columnheader in columnheaders)
        {
            datatable.Columns.Add(columnheader); // I've added the column headers here.
        }

        // Populate Table 
        while (streamreader.Peek() > 0) // if any
        {
            DataRow datarow = datatable.NewRow();
            datarow.ItemArray = streamreader.ReadLine().Split(delimiter.ToCharArray());
            datatable.Rows.Add(datarow);
        }

        if (printoutfilereading)  Debug.Log("Loaded Text File: " + fileName);
        // Debug 
        if(printoutfilereading)
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
