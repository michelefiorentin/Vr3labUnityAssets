using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Educationaldata : MonoBehaviour
{
    [Tooltip("This is the main title")]
    public string titolo;
    [Tooltip("This is the list of descriptions")]

    public List<string> captions= new List <string>();
    public int next_index = 0;
    public string language = "ita";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string getRotatingCaption()
    {
  
        return getcaptionVerified(next_index);

    }
    public string getTitle()
    {

        return titolo;

    }

    string getcaptionVerified(int i)
    {
        string temp ;
        if (i <= captions.Count && i >= 0)
        {
            temp = captions[i];
            next_index = i + 1;
            if (next_index == captions.Count) next_index = 0;
        }
        else
        {
            temp = "non so chi sono!";
        }
        return temp;
    }


}
