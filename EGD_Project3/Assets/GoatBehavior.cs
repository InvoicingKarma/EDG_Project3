using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class GoatBehavior : MonoBehaviour
{
    Vector2 bounds = new Vector2(9f, 5f);
    public float speed = 2.0f;
    Rigidbody2D rb;
    public static bool respawning = false;
    public GameObject foot;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        foot = GameObject.FindGameObjectWithTag("Foot");
        rb = GetComponent<Rigidbody2D>();
        respawning = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private Vector3 posLastFrame = Vector3.zero;
    void Update()
    {
        Vector3 totalMovement = Vector3.zero;
        //float mySpeed = vel.magnitude;

        //animator.SetFloat("Speed", Mathf.Abs(mySpeed));
        //Debug.Log(Mathf.Abs(mySpeed));
        transform.position = my_math.Wrap(transform.position, bounds);

        if (Input.GetKey(KeyCode.W))
        {
            totalMovement += transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            totalMovement -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            totalMovement -= transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            totalMovement += transform.right;
        }

        animator.SetFloat("Speed", Mathf.Abs(totalMovement.magnitude));
        //Debug.Log(Mathf.Abs(totalMovement.magnitude));
        
        // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
        rb.MovePosition(transform.position + totalMovement.normalized * speed * Time.deltaTime);
        posLastFrame = transform.position;

        if (respawning == true)
        {
            Debug.Log("I'm respawning");
            animator.SetBool("IsStomped", true);
        }
    }
}