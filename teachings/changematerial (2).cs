using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//http://ogrehead.com/2015/09/how-to-lightmap-in-unity-5/

// by Michele Fiorentino
// 14-3-2017
// usage:
// 1) set text caption in teh text component
// 2) Size manually the collider area component
// 3) Assign function in the code
// enjoy!

public class changematerial : MonoBehaviour
{

    private Animator myanim;
    // Use this for initialization
    public int showtimes= 0; // 0 = infinite = all times
    public Material[] mymaterials;
    public GameObject[] mychangecolor_objects;
    private int index = 0;
    
    //private bool allmarterialInstances = false; // not working now, so not exposed


    void Start()
    {
        myanim = GetComponent<Animator>();
        myanim.SetBool("is_inside", false);
    }

    void OnTriggerStay(Collider other)
    {
         if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.M))
        {
             Debug.LogWarning("fire!" );
            changecolor();
        }
        //
        
        else if (other.name == "animationcollider")
        {
            //changecolor();
            Debug.LogWarning("startanimation");
        }
        //
    }


    void OnTriggerEnter(Collider other)
    {
        //myanim.SetTrigger("appear");
        myanim.SetBool("is_inside", true);
        // myanim.SetBool("doitappear",  true);
        Debug.Log("colided");
    }
    
    void OnTriggerExit(Collider other)
    {
        myanim.SetBool("is_inside", false);

    }
     


    private void changecolor ()
    {
        if (index < mymaterials.Length)
        {
            foreach (GameObject myobject in mychangecolor_objects) //the line the error is pointing to
            {
                Renderer myrend = myobject.GetComponent<Renderer>();
                //if (allmarterialInstances ==true) myrend.sharedMaterial = mymaterials[index];
                myrend.material = mymaterials[index];
            }
            index = index + 1;
        }
        else
        {
            index = 0;
            foreach (GameObject myobject in mychangecolor_objects) //the line the error is pointing to
            {
                Renderer myrend = myobject.GetComponent<Renderer>();
                //if (allmarterialInstances ==true) myrend.sharedMaterial = mymaterials[index];
                myrend.material = mymaterials[index];
            }
        }
            
        //Debug.Log("material changed");
        // Debug.LogWarning("index=" + index);
    }
   
    /*
    private void replaceallMaterialsbyname(string orig_matname, Material target_mat)
    {
        GameObject[] myobjs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject myobject in myobjs)
        {
            Renderer myrend = myobject.GetComponent<Renderer>();
            foreach (Material mymat in myrend.sharedMaterials)
            {
                if (mymat != null && mymat.name.Equals(orig_matname))
                {
                    Debug.Log("found material:" + orig_matname + "!");
                    mymat = target_mat;
                }
                else
                {
                    Debug.Log("Missing material in game object '" + renderer.name + "'");
                }
            }
        }
        // check if target is available
    }

    */
}