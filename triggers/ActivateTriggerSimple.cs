/// This simple script triggers a custom event 
/// the Gameobject requires a collider with is triggered enabled 
/// By Michele Fiorentino
/// Politecnico di bari
/// Copyright 2022
/// 
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class ActivateTriggerSimple : MonoBehaviour
{
    // A multi-purpose script which causes an action to occur when
    // a trigger collider is entered.
    [Tooltip("Put here events to be triggered")]
    public UnityEvent yourCustomEvent; // the events to be run
    [Tooltip("Put here scenes to be loaded")]
    public string SceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (yourCustomEvent != null)
        {
            yourCustomEvent.Invoke();
            //Debug.Log("custome event invoked");
        }
        if (!string.IsNullOrEmpty(SceneName))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}

