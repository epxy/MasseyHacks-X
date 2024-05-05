<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO.Ports;
using TMPro;

public class SerialCommunicator : MonoBehaviour
{
    // Start is called before the first frame update

    SerialPort stream = new SerialPort("COM9", 19200);

    public Vector2 joyStickValues;

    public int[] pushbuttons = { 0, 0, 0, 0 };

    public Vector3 accelerometerOutputSpeed;

    string inputString;


    void Start()
    {
        stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputString = stream.ReadLine();


        string[] output = inputString.Split(',');
        for (int i = 0; i < 4; i++) pushbuttons[i] = int.Parse(output[i]);
        accelerometerOutputSpeed.x = int.Parse(output[4]); accelerometerOutputSpeed.y = int.Parse(output[5]); accelerometerOutputSpeed.z = int.Parse(output[6]);
        joyStickValues.x = int.Parse(output[7]); joyStickValues.y = int.Parse(output[8]);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO.Ports;
using TMPro;

public class SerialCommunicator : MonoBehaviour
{
    // Start is called before the first frame update

    SerialPort stream = new SerialPort("COM9", 19200);

    public Vector2 joyStickValues;

    public int[] pushbuttons = { 0, 0, 0, 0 };

    public Vector3 accelerometerOutputSpeed;

    string inputString;


    void Start()
    {
        stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputString = stream.ReadLine();


        string[] output = inputString.Split(',');
        for (int i = 0; i < 4; i++) pushbuttons[i] = int.Parse(output[i]);
        accelerometerOutputSpeed.x = int.Parse(output[4]); accelerometerOutputSpeed.y = int.Parse(output[5]); accelerometerOutputSpeed.z = int.Parse(output[6]);
        joyStickValues.x = int.Parse(output[7]); joyStickValues.y = int.Parse(output[8]);
    }
}
>>>>>>> Stashed changes
