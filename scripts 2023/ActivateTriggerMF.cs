/// Simple script for triggers a custom event 
/// the Gameobject requires a collider with is triggered enabled 
/// Instructions:
/// 1) add to gameobject with collider
/// 2) set collider as Trigger (e.g. Boxcollider)
/// 3) add yourCustomEvent\s it will be triggered on enter

/// By Michele Fiorentino
/// Politecnico di Bari
/// Copyright 2022
/// In case of issues or bugs email fiorentino@poliba.it - give details
/// V2 : with enum status
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class ActivateTriggerMF : MonoBehaviour
{

        [Tooltip("USAGE:1) add to gameobject with collider  2) set collider as Trigger (e.g. Boxcollider)  3) add yourCustomEvent/s it will be triggered on enter ")]

    // A multi-purpose script which causes an action to occur when
    // a trigger collider is entered.x

    public enum MyConditions // *
    {
        OnEnter,
        OnStay,
        OnExit,
    }
    public MyConditions myCondtion;

    [Tooltip("Put here events to be triggered")]
    public UnityEvent OnCustEvent; // the events to be run
    [Tooltip("Put here scenes to be loaded")]
    public string SceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (myCondtion == MyConditions.OnEnter)
        {
            invokeCustom();
        }
     }

    private void OnTriggerStay(Collider other)
    {
        if (myCondtion == MyConditions.OnStay)
        {
            invokeCustom();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (myCondtion == MyConditions.OnExit)
        {
            invokeCustom();
        }
    }



    private void invokeCustom()
    {
        if (OnCustEvent != null)
        {
            OnCustEvent.Invoke();
            //Debug.Log("custome event invoked");
        }
        if (!string.IsNullOrEmpty(SceneName))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}

