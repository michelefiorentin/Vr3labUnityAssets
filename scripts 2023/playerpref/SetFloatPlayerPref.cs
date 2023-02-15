// MIchelefiorenitno 14-2-2023
// FUNCTION:
// save and load preferences in fexible way
// load scene
// Note: default is 0
// USAGE:
// 1) create gameobject + add this script
// 2) call public read and write 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatPlayerPref : MonoBehaviour
{
    [Tooltip("Persistentname")]
    public string persistent_variable_name="lux";

    [Tooltip("this the current value")]
    public float  current_persistent_variable_value;

    [Tooltip("if activate, saves current value")]
    public bool SetInitial = true;

    // Start is called before the first frame update
    void Start()
    {
        if (SetInitial) WriteToPlayerPref(current_persistent_variable_value);
        else ReadFromPlayerPref();
    }

  // 
  public void WriteToPlayerPref(float p_value)
    {
        PlayerPrefs.SetFloat(persistent_variable_name, p_value);
        print("Set "+ persistent_variable_name+" value: " + p_value);
    }

    public void ReadFromPlayerPref()
    {
        current_persistent_variable_value = PlayerPrefs.GetFloat(persistent_variable_name, 0f);
        print("Got " + persistent_variable_name + " value: " + current_persistent_variable_value);
    }

}
