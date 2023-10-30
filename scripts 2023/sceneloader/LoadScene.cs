/*
IMPORTANT WARNING: uses legacy input system
Copyright Michele Fiorentino 2021 - 23 Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
30-10-23 improved 
Usage: 
1) create target scene give an easyname (no spaces)
2) add target scene to Build settings
3) set the name of the scene (with spaces)
4) call public loadscene or debug key (using legacy input - may not work on new input system)  
*/
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    public class LoadScene : MonoBehaviour
    {
        [Tooltip("Set here the key name- default is a")]
        public string keyname ="s";
        [Tooltip("Set here the Name of the Scene (no .unity extension needed)- scene must be added to the build scenes")]
        public string scene_to_be_loaded =""; // the events to be run

        private void Update()
        {
            if (Input.GetKeyDown(keyname))
            {
            Debug.Log("Fired key: " + keyname);
            loadScene();

            }
        }

    public void loadScene(string p_scene)
    {

        if (!String.IsNullOrEmpty(p_scene))
        {
            Debug.Log("Loading: " + p_scene);
            SceneManager.LoadScene(p_scene);
        }
    }

    public void loadScene()
    {
        loadScene(scene_to_be_loaded);
    }
}

