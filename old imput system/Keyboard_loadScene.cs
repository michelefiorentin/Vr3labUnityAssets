/*
IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
Usage: 
1) create target scene give an easyname (no spaces)
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
    public class Keyboard_loadScene : MonoBehaviour
    {
        [Tooltip("Set here the key name- default is a")]
        public string keyname ="s";
        [Tooltip("Set here the Name of the Scene (no .unity extension needed)- scene must be added to the build scenes")]
        public string scene_to_be_loaded =""; // the events to be run

        private void Update()
        {
            if (Input.GetKeyDown(keyname))
            {
                Debug.Log("Fired key: "+ keyname);
                if (!String.IsNullOrEmpty(scene_to_be_loaded))
                {
                    SceneManager.LoadScene(scene_to_be_loaded);
                }
            }
        }

    }
}
