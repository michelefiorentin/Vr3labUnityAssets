/// By Michele Fiorentino
/// Politecnico di Bari
/// Copyright 2022
/// In case of issues or bugs email fiorentino@poliba.it - give details

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//http://ogrehead.com/2015/09/how-to-lightmap-in-unity-5/

// Cycles Material pressing keys button (space default)
// WARNING: legay input system required
// by Michele Fiorentino
// 14-3-2017
// 28-12-2022 cleanup an dimprove
// usage:
// 1) Create \find materials and add to Array
// 2) Add OBjects
// 3) set buttons
// enjoy!

public class ChangeMaterial : MonoBehaviour
{
    [Tooltip("Button tio be pressed to cycle material - fefault space")]
    public string buttonName ="space";

    [Tooltip("Set materials to cycle")]
    public List<Material> materialsList;

    [Tooltip("Set Objects to apply materials")]
    public List<GameObject> changecolorOjectsList;
    [SerializeField]
    private int index = 0;
    

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(buttonName))
        {
            Debug.Log(buttonName+"Pressed!");
            if (materialsList.Count > 0 && changecolorOjectsList.Count > 0)
                cycleMaterials();
            else Debug.LogWarning("WARNING: no objects or material in list!" );
        }
    }


    public void cycleMaterials ()
    {
        // for each material 
 
            foreach (GameObject myobject in changecolorOjectsList) //the line the error is pointing to
            {
                Renderer myrend = myobject.GetComponent<Renderer>();
                //if (allmarterialInstances ==true) myrend.sharedMaterial = mymaterials[index];
                myrend.material = materialsList[index];
            }
        // increment  index
        index = index + 1;
        if (index >= materialsList.Count) index = 0;

           
        //Debug.Log("material changed");
        // Debug.LogWarning("index=" + index);
    }
   
    
}