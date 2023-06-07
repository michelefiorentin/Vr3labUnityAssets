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
// 7/6/23 add material index
// usage:
// 1) Create \find materials and add to Array
// 2) Add OBjects
// 3) set buttons -call cycleMaterials 
// enjoy!

public class ChangeMaterial : MonoBehaviour
{



    [Tooltip("Set materials to cycle")]
    public List<Material> inputMaterials;

    [Tooltip("Set Objects to apply materials")]
    public List<GameObject> TargetObjectsToBeChanged;
    
    [Tooltip("material index in the objects to be changed")]
    public int targetMaterialindex = 0;

    [Tooltip("Button tio be pressed to cycle material - fefault space")]
    public bool keyinputactivated = false;

    [Tooltip("(check flag) Button tio be pressed to cycle material - fefault space")]
    public string buttonName = "space";

    void Start()
    {
        
    }

    private void Update()
    {
        if (keyinputactivated && Input.GetKeyDown(buttonName))
        {
            Debug.Log(buttonName+"Pressed!");
            if (inputMaterials.Count > 0 && TargetObjectsToBeChanged.Count > 0)
                cycleMaterials();
            else Debug.LogWarning("WARNING: no objects or material in list!" );
        }
    }


    public void cycleMaterials ()
    {
        // for each material 
 
            foreach (GameObject myobject in TargetObjectsToBeChanged) //the line the error is pointing to
            {
                // renderer is local as it is applied to multiple game objects
                Renderer myrend = myobject.GetComponent<Renderer>();
                //if (allmarterialInstances ==true) myrend.sharedMaterial = mymaterials[index];
                myrend.material = inputMaterials[targetMaterialindex];
            }
        // increment  index
        targetMaterialindex = targetMaterialindex + 1;
        if (targetMaterialindex >= inputMaterials.Count) targetMaterialindex = 0;

           
        //Debug.Log("material changed");
        // Debug.LogWarning("index=" + index);
    }
   
    
}