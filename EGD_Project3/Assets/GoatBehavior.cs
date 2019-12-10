using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatBehavior : MonoBehaviour
{
    Vector2 bounds = new Vector2(9f, 5f);
    public float speed = 2.0f;
    Rigidbody2D rb;
    public static bool respawning = false;
    public GameObject foot = GameObject.FindGameObjectWithTag("Foot");
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.GetComponent<Animator>();

        respawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 totalMovement = Vector3.zero;

        transform.position = my_math.Wrap(transform.position, bounds);

        if (Input.GetKey(KeyCode.W))
        {
            totalMovement += transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            totalMovement -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            totalMovement -= transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            totalMovement += transform.right;
        }

        // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
        rb.MovePosition(transform.position + totalMovement.normalized * speed * Time.deltaTime);
    }

    void RespawnGoat()
    {

        respawning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objectTag = collision.gameObject.tag;

        if (respawning)
        {
            return;
        }

        if (objectTag == "Foot")
        {
            //Do the squish animation
            respawning = true;
            Invoke("RespawnGoat", 3f);
        }
    }
}