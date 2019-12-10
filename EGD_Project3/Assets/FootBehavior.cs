using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBehavior : MonoBehaviour
{
    Vector2 bounds = new Vector2(9f, 5f);
    public float speed = 2.0f;
    Rigidbody2D rb;
    public bool enter = true;
    public GameObject goat;

    // Start is called before the first frame update
    void Start()
    {
        goat = GameObject.FindGameObjectWithTag("Goat");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 totalMovement = Vector3.zero;

        transform.position = my_math.Wrap(transform.position, bounds);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            totalMovement += transform.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            totalMovement -= transform.right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            totalMovement -= transform.up;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            totalMovement += transform.right;
        }

        // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
        rb.MovePosition(transform.position + totalMovement.normalized * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("I was pressed");
            //Play the stomp animation
            //Look to see if the goat is under it
                //if it is tell it that and have it play the stomped animation and start respawning
            //Add a tally to a score tracker?
        }
    }
}