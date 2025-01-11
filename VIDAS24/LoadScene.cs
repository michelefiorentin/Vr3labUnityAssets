/*
IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2023 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
Usage: 
1) create a empty object
2) add target scene to Build settings
3) set key and the name of the scene (avoid spaces)
4) enjoy
*/
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class LoadScene : MonoBehaviour
    {
        [Tooltip("Set here the Name of the Scene (no .unity extension needed)- scene must be added to the build scenes")]
        public bool startAtactivation  = true; // the events to be run
 
        [Tooltip("Set here the Name of the Scene (no .unity extension needed)- scene must be added to the build scenes")]
        public string scene_to_be_loaded =""; // the events to be run

        [Tooltip("This public script can be calle dal so from Custom event")]
        public void loadscene()
        {
            if (!String.IsNullOrEmpty(scene_to_be_loaded))
            {
                print("load" + scene_to_be_loaded);
                SceneManager.LoadScene(scene_to_be_loaded);
            }

        }

        private void Start()
        {
            if (startAtactivation) loadscene();
       
            //loadscene();
        }

    }
}
