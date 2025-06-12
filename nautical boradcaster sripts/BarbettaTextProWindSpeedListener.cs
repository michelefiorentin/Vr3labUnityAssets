//C:\0-github\NavigaAR\0-NavigAr\Assets\NauticalBroadcast\sripts\BarbettaTextProWindSpeedListener.cs

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Copyright Michele Fiorentino michele.fiorentino@poliba.it
/// Printouts in teh text the windangle value
/// this script must be attached to a gameobject with 
/// </summary>
[RequireComponent(typeof(TextMeshPro))]
public class BarbettaTextProWindSpeedListener : MonoBehaviour
{
    public int decimalDigits = 0;
    public char mybarbettachar = 'I';
    public float  onebarbettaValue = 1f;
    //public NauticalEventBroadcasterFromFile myhandler;
    private TextMeshPro mytext;

    // Start is called before the first frame update
    void Start()
    {
        mytext = GetComponent<TextMeshPro>();
        if (mytext == null) Debug.LogError("TextProWindSpeedListener- not found component TextMeshPro ");
        // subscribe
        NauticalEventBroadcasterFromFilePretest.WindChanged += OnWindChanged;
    }

   
    public void OnWindChanged (object source, WindEventArgs wind)
    {
        int numbarbettas = (int )(wind.Speed / onebarbettaValue);
        string result = new string(mybarbettachar, numbarbettas);
        mytext.text = wind.Speed.ToString(result);
        //Debug.Log("Listerer :"+ wind.Dump());
    }
}
