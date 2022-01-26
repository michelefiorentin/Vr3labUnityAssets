/* 
IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
Usage: 
1) add to the object to move 
2) set keys
3) set axis of rotation (workd space)
4) set step increment
5) (optional) drag an instance to texpro for value update
6) enjoy
 */
/// <summary>
/// Copyright 2021 Michele Fiorentino  - Politecnico di Bari
/// Attach to object and it can be rotated accoding keypress
/// </summary>
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keyrotator : MonoBehaviour
{
    [TextArea]
    public string Notes = "Copyright 2021 Michele Fiorentino  - Politecnico di Bari\n";

    [Tooltip("Angle of rotation")]
    private float myValue;

    [Tooltip("Key1 addition")]
    public string plus_key = "d";
    [Tooltip("Key2 subtraction")]
    public string minus_key = "f";
    [Tooltip("Axis of rotation")]
    public Vector3 myaxis = new Vector3(1, 0, 0);
    [Tooltip("value of rotation per keypress")]
    public float step = 5;
    [Tooltip("TExtpro to modify")]
    public TMP_Text myTextpro;
    [Tooltip("Display String text")]
    public string mystring ="Value: ";


    private const float MIN_ANGLE = 0;


    private void Start()
    {
         myValue = MIN_ANGLE;
    }


    private void Update()
    { 
        if (Input.GetKeyDown(plus_key))
        {
   
            myangleupdate(step);
        }
        else
        if (Input.GetKeyDown(minus_key))
        {

            myangleupdate(-step);
        }

    }
  
    private void myangleupdate(float p_step)
    {
        myValue = myValue + p_step;
        gameObject.transform.Rotate(myaxis, p_step);
        if (myTextpro != null)
        {
            //print("here"+myValue);
            myTextpro.text = mystring + myValue.ToString("0");// digits
        }
    }

}
