using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


/// <summary>
///  
/// --previous people
/// 0-7-2021 - script updated by michele Fiorentino 
///  
/// </summary>
public class TextFileReaderTime : MonoBehaviour
{
    [Tooltip("File di testo da cercare in Application.dataPath")]
    public string fileName = "wind_speed.txt"; // Cerca in Application.dataPath 
    [Tooltip("delta time of update = each line time")]
    public float deltatime = 5.0f;
    [Tooltip(" ths is the object conaining Ui.Text")]
    public GameObject ObjectText;// ths is the object conaining Ui.Text
    [Tooltip(" unit to display")]
    public string units = " Kts ";
    // private
    private string[] numbersArray;
    private string myFilePath;

    // Start is called before the first frame update

    void Start()
    {
        // myFilePath = Application.dataPath + "/" + fileName;
        Debug.Log("Loading Text File: " + myFilePath);
        myFilePath = fileName;
        StartCoroutine(ReadFromTheFile());

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator ReadFromTheFile()
    {
        numbersArray = File.ReadAllLines(myFilePath);
        foreach (string line in numbersArray)
        {
            //Debug.Log(line);
            //if (!wind) Debug.LogError("TextFileReaderTime ERROR: l'oggeto Objecttextcontainer non contiene oggetto Ui.text!");
            //wind.text = line+ units;
            ObjectText.GetComponent<Text>().text= line + units;
            yield return new WaitForSeconds(deltatime);
        }

    }
}
