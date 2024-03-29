// activates 1 object pe rtime rotating between

using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitch : MonoBehaviour
{
    public GameObject[] objects;
    public Text text;

    private int m_CurrentActiveObject;


    private void OnEnable()
    {
        text.text = objects[m_CurrentActiveObject].name;
    }


    public void NextObj()
    {
        int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == nextactiveobject);
        }

        m_CurrentActiveObject = nextactiveobject;
        text.text = objects[m_CurrentActiveObject].name;
    }
}
