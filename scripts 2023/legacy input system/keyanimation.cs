// Ciopyright Michele Fiorentino
//10-11-2022
// v1
// Info : triggers animation at keypress 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class keyanimation : MonoBehaviour
{
    [Tooltip("Mandatory Animator")]
    public Animator myanimator;

    [Tooltip("Key to be pressed")]
    public string keyname = "a";
    
    [Tooltip("Write here the name of the Animator trigger")]
    public string triggername = "attack";



    // Start is called before the first frame update
    void Start()
    {
        if (myanimator == null) print("ATTENTIN: Drag the animator");
    }

    void Update()
    {
        

        if (Input.GetKeyDown(keyname))
        {
            print("space key was pressed");
             myanimator.SetTrigger(triggername);
        }
    }
}
