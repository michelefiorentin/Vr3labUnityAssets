/*
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license

FUCTIONS:
1-Given keyname (cusomizable), executes event at keydown (customizable)
2- if scene name is filled it load at that keypress
3- if boolena esc quit is turned on app will close when compiled on esc

NOTES: meant to use both old an new systems, but this can have soem performance loss (expecially if used with may isntances)
 
 */
using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardCustomEventNG: MonoBehaviour
{
    [Tooltip("Set here the key name- default is a key")]
    public string keyname = "a";
    [Tooltip("Set here the object and the Event at keypress")]
    public UnityEvent keypressCustomEvent; // the events to be run

    [Tooltip("Name of the Scene (without .unity extension)- WARNING:add scene to the build")]
    public string scene_to_be_loaded = ""; // the events to be run

    [Tooltip("Quit from application using ESC key")]
    bool quitonesc = false;

    private void Update()
    {
        if (checkButtonisFired(keyname))
        {
            onButtonPressed();
            loadScene();
        } else if (quitonesc && checkEscapeisFired())
        {
            Debug.Log("Escape key was pressed- Quitting");
            Application.Quit();
        }
    }

    void onButtonPressed()
    {
        Debug.Log("Fired key: " + keyname);
        if (keypressCustomEvent != null)
        {
            keypressCustomEvent.Invoke();
        }
 
    }

    void loadScene ()
    {
        // if scene is set call it
        if (!String.IsNullOrEmpty(scene_to_be_loaded))
        {
            SceneManager.LoadScene(scene_to_be_loaded);
        }
    }

    bool checkButtonisFired(string p_keyname)
    {
        bool tempfire = false;
#if ENABLE_LEGACY_INPUT_MANAGER
    // Old input backends are enabled.
    tempfire = Input.GetKeyDown(p_keyname);
#endif

#if ENABLE_INPUT_SYSTEM
    // New input system backends are enabled.
    tempfire = ((KeyControl)Keyboard.current[p_keyname]).wasPressedThisFrame();
#endif

        return tempfire;
    }


    bool checkEscapeisFired()
    {
        bool tempfire = false;
#if ENABLE_LEGACY_INPUT_MANAGER
    // Old input backends are enabled.
    tempfire = Input.GetKeyDown(KeyCode.Escape);
#endif

#if ENABLE_INPUT_SYSTEM
    // New input system backends are enabled.
    tempfire = ((KeyControl)Keyboard.current[KeyCode.Escape]).wasPressedThisFrame();
#endif
        return tempfire;
    }

}
