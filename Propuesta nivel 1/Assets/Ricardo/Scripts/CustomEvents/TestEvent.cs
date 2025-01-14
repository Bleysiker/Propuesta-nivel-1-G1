using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    public CustomEvents evento;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            Debug.Log("se disparo el evento");
            evento.FireEvent();
        }
    }
}
