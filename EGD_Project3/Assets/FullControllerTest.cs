using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class FullControllerTest : MonoBehaviour
{
    public int speed = 3;
    public UduinoManager u;
    //public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //isPaused = false;
        u = UduinoManager.Instance;
        u.DiscoverPorts();
        for (int i = 2; i < 12; i++)
        {
            u.pinMode(i, PinMode.Input_pullup);
            Debug.Log("Pin " + i + " initiated.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (u.digitalRead(2) == 0 || u.digitalRead(6) == 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (u.digitalRead(3) == 0 || u.digitalRead(7) == 0)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (u.digitalRead(4) == 0 || u.digitalRead(8) == 0)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (u.digitalRead(5) == 0 || u.digitalRead(9) == 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        /*if (u.digitalRead(10) == 0 || u.digitalRead(11) == 0)
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;*/

    }

}
