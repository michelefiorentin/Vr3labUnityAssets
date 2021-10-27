using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by Michele Fiorentino
// 14-3-2017
// usage:
// 1) apply this script to the FPControl
// 2) Create a Collider (= any object with collider and assign name colorcollider
// 3) assign material and gameobject from editor to the script public matixes 
// enjoy!

public class changematerial : MonoBehaviour
{
    public Material[] mymaterials;
    public GameObject[] mychangecolor_objects;
    private int index = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "colorcollider")
        {
            changecolor();
            Debug.LogWarning("changecolor");
        }
        else if (other.name == "animationcollider")
        {
            //changecolor();
            Debug.LogWarning("startanimation");
        }
        
}


   private void changecolor ()
    {
        foreach (GameObject myobject in mychangecolor_objects) //the line the error is pointing to
        {
            Renderer myrend = myobject.GetComponent<Renderer>();
            myrend.material = mymaterials[index];
        }

        if (++index >= mymaterials.Length)
        {
            index = 0;
        }
       // Debug.LogWarning("index=" + index);
    }
}