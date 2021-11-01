/*
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
*/
using System;
using UnityEngine;
using UnityEngine.Events;


namespace UnityStandardAssets.Utility
{
    public class Keyboard_customeevent : MonoBehaviour
    {
        [Tooltip("Set here the key name- default is a")]
        public string keyname ="a";
        [Tooltip("Set here the object and the Event at keypress")]
        public UnityEvent keypressCustomEvent; // the events to be run

        private void Update()
        {
            if (Input.GetKeyDown(keyname))
            {
                Debug.Log("Fired key: "+ keyname);
                if (keypressCustomEvent != null)
                {
                    keypressCustomEvent.Invoke();
                }
            }
        }

    }
}
