///summary
// 09/06/2022 Michele Fiorentino
// This is a very flexible data writer for textual, csv file
// file name is automatic, in Application.persistentDataPath , filename: "p_filenamedecoration"-timestring

// FUCTIONS: 
// 1- Automatic csv\text file naming 
// 2- "IDTarget;taskmemillisec;payload"

// FIND files
// OCULUS QUEST 2 connetced to cable Questo PC\Quest 2\Internal shared storage\Android\data\com.PolitecnicodiBari."nome app"\files\Risultati
// Desktop  : read console e.g. C:/Users/miche/AppData/LocalLow/DefaultCompany/Bag_UI/TreatmentA/
//
/*
 * 
 * Android: Application.persistentDataPath points to /storage/emulated/0/Android/data/<packagename>/files on most devices
 * (some older phones might point to location on SD card if present), 
 * the path is resolved using android.content.Context.getExternalFilesDir
 * 
 */
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Events;


public class FlexibleFileWriter : MonoBehaviour
{
    // publics

    [Header("-------File Setups-------")]
    [Tooltip("This id subdirectory in Application.persistentDataPath ")]
    public string subDirectory = "TreatmentA";

    [Tooltip("Field Separator, avoid comma as italian excel uses it for sepatate decimals")]
    public string outpseparator = ";";

    [Tooltip("File extension, cvs is ok for excel")]
    public string outputFileExtension = ".csv";

    [Header("-------Public only for debug-------")]
    // current target public for display 

    // privates
    private string outfilepath; // this is the current filename
    private DateTime targetStartTime; // this is teh initial time form experiment 
    public int currentIndex = 0; // just a counter
    void Start()
    {
           InizializeFile(subDirectory);
    }
 
    // Opens new file and reset indexes(attention string must be compatible with filesystem
    public void InizializeFile(string p_filenamedecoration)
    {
        // opens file in user path 
        string t_userdirectory = Application.persistentDataPath + "/" + subDirectory + "/";

        //Create folder if not exist creates it
        if (!Directory.Exists(t_userdirectory))
        {
            Debug.Log("Created directory:" + t_userdirectory);
            Directory.CreateDirectory(t_userdirectory);
        }

        //Create Filename and if it doesn't exist folder creates it
        outfilepath = t_userdirectory + p_filenamedecoration + System.DateTime.Now.ToString("-yyyy-MM-dd-HH-mm-ss") + outputFileExtension;

        if (!File.Exists(outfilepath))
        {
            TextWriter tw = new StreamWriter(outfilepath, false);
            tw.WriteLine("ID;taskmemillisec;event");
            tw.Close();
            Debug.Log("Created file log: " + outfilepath);
        }

        // reset indexes
        currentIndex = 0;
        targetStartTime = DateTime.Now;

    }
    public void FSsaveEntry(string res)
    {
        string deltatimestring = (DateTime.Now - targetStartTime).TotalMilliseconds.ToString("f0");
        string stringPayload = currentIndex++ + outpseparator + deltatimestring + outpseparator + res + "\n";
        File.AppendAllText(outfilepath, stringPayload);
        Debug.Log("saved:" + stringPayload);
    }

      
}
