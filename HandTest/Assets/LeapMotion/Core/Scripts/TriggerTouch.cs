using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Linq;

public class TriggerTouch : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM7", 115200, Parity.None, 8, StopBits.One);

    private void Update()
    {
     
    }

    private void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1; //Shortest possible read time out.
        sp.WriteTimeout = 1; //Shortest possible write time out.

        if (sp.IsOpen)
            Debug.Log("Connected");
        else
            Debug.Log("Not Connected");
    }

    void OnTriggerEnter(Collider col)
    {

        //if (sp.IsOpen)
            sp.Write("Hello World");
        //else
            //sp.Open();
        //Debug.LogError("Serial port: " + sp.PortName + " is unavailable");

        Debug.Log(col.gameObject.name);
        //sp.Close();
    }
}

