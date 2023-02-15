// MIchelefiorenitno 14-2-2023
// FUNCTION:
// find current lux level form playerpref "lux" key
// load postporcess profile accordinly
// load scene
// 
// USAGE:
// 1) add to ppstprocess volume
// 2) add total 7 postprocessprofile
// WARNING: mandatory  7 postprocessprofiles

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



[RequireComponent(typeof(PostProcessVolume))]
public class LuxLoadPostprocess : MonoBehaviour
{

    [Tooltip("this the lux persistent name string")]
    public string persistent_lux_variable_name= "lux";

    [Tooltip("Drag here postprocess")]
    public PostProcessVolume m_Volume;

    [Tooltip("set postprocess list")]
    public List<PostProcessProfile> luxsettings;


    // Start is called before the first frame update
    void Start()
    {
        float persistentLux = PlayerPrefs.GetFloat(persistent_lux_variable_name, 0f);

        switch (persistentLux)
        {
            case 1f:
                // code block
                m_Volume.profile = luxsettings[0];
                break;
            case 2:
                // code block
                m_Volume.profile = luxsettings[1];
                break;
            case 3:
                // code block
                m_Volume.profile = luxsettings[2];
                break;
            case 4:
                // code block
                m_Volume.profile = luxsettings[3];
                break;
            case 5:
                // code block
                m_Volume.profile = luxsettings[4];
                break;
            case 6:
                // code block
                m_Volume.profile = luxsettings[5];
                break;
            case 7:
                // code block
                m_Volume.profile = luxsettings[6];
                break;
            default:
                // code block

                Debug.LogWarning("NO lux  " + persistentLux + "profile found, so NO PP profile si loaded");
                break;
        }

    }

}
