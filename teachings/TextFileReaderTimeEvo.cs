using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Data;

/// <summary>
///  
/// --previous people
/// 7-9-2021 - script updated by michele Fiorentino 
/// 8/7-2021 evo started 
/// </summary>
public class TextFileReaderTimeEvo : MonoBehaviour
{
    [Tooltip("File ; separated txt file  da cercare in Asset path")]
    public string fileName = "wind_speed.txt"; // default
    [Tooltip("delta time of update = each line time")]
    public float deltatime = 5.0f;
    [Tooltip(" ths is the object conaining Ui.Text")]
    public GameObject ObjectText;// ths is the object conaining Ui.Text
    [Tooltip(" unit to display")]
    public string units = " Kts ";
    // private
    private string[] numbersArray; // to be replaced
    DataTable datatable = new DataTable();
    char[] delimiter = new char[] { ';' };

    // Start is called before the first frame update

    void Start()
    {
        // myFilePath = Application.dataPath + "/" + fileName;
        Debug.Log("Loading Text File: " + fileName);
        advancedTxtReader();
        Datainfo();
        dumpRow(2);
        //StartCoroutine(ReadFromTheFile());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator ReadFromTheFile()
    {
        numbersArray = File.ReadAllLines(fileName);
        foreach (string line in numbersArray)
        {
            //Debug.Log(line);
            //if (!wind) Debug.LogError("TextFileReaderTime ERROR: l'oggeto Objecttextcontainer non contiene oggetto Ui.text!");
            //wind.text = line+ units;
            ObjectText.GetComponent<Text>().text= line + units;
            yield return new WaitForSeconds(deltatime);
        }
    }

    void advancedTxtReader()
    {
        StreamReader streamreader = new StreamReader(fileName);
        string[] columnheaders = streamreader.ReadLine().Split(delimiter);

        // pupulate the header
        foreach (string columnheader in columnheaders)
        {
            datatable.Columns.Add(columnheader); // I've added the column headers here.
        }
        // Populate rows 
        while (streamreader.Peek() > 0) // if any
        {
            DataRow datarow = datatable.NewRow();
            datarow.ItemArray = streamreader.ReadLine().Split(delimiter);
            datatable.Rows.Add(datarow);
        }
    }

    void Datainfo()
    {
        Debug.Log("---Columns: " +datatable.Columns.Count+ " Rows: " + datatable.Rows.Count);
    }

    void dumpRow(int index)
    {
        if (index >= 0 && index<datatable.Rows.Count)
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



        void dumpData()
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
                    Debug.Log(column.ColumnName +" "+ row[column]);
                }
            }
        }
     
    }

}
