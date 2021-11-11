/// This simple script triggers a custom event 
/// the Gameobject requires a collider with is triggered enabled 
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActivateTrigger_final : MonoBehaviour
    {
        // A multi-purpose script which causes an action to occur when
        // a trigger collider is entered.
        public UnityEvent yourCustomEvent; // the events to be run

        private void OnTriggerEnter(Collider other)
        {
            if (yourCustomEvent != null)
            {
                yourCustomEvent.Invoke();
                //Debug.Log("custome event invoked");
            }
        }
    }

