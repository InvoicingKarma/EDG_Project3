using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Movement_Temp : MonoBehaviour
{
    public int speed = 3;
    public UduinoManager u;

    // Start is called before the first frame update
    void Start()
    {
        u = UduinoManager.Instance;
        u.DiscoverPorts();
        for (int i = 2; i < 6; i++)
        {
            u.pinMode(i, PinMode.Input_pullup);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (u.digitalRead(2) == 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (u.digitalRead(3) == 0)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (u.digitalRead(4) == 0)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (u.digitalRead(5) == 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
