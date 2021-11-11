/*
Copyright Michele Fiorentino 2021 - Politecnico di Bari
fiorentino@poliba.it
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
note: to be tested
*/
/// <summary>
/// Copyright 2021 Michele Fiorentino  - Politecnico di Bari
/// CustomSceneload Attach the script to the triggered GameObject 
/// </summary>

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;



namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActivateTriggerSceneload : MonoBehaviour
    {
        [Tooltip("Check trigger present-Set here the Name of the Scene (no .unity extension needed)- scene must be added to the build scenes")]
        public string scene_to_be_loaded = ""; // the events to be run

         private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Fired trigger: ");
            if (!String.IsNullOrEmpty(scene_to_be_loaded))
            {
                SceneManager.LoadScene(scene_to_be_loaded);
            }
        }
    }
}
