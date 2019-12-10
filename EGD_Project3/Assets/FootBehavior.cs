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
    public GameObject foot;
    public AnimationClip stomp;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        goat = GameObject.FindGameObjectWithTag("Goat");
        foot = GameObject.FindGameObjectWithTag("Foot");
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
            anim.clip = stomp;
            anim.Play();

            Vector2 goat_pos = goat.transform.position;
            Vector2 foot_pos = foot.transform.position;

            if (Mathf.Round(goat_pos.x) == Mathf.Round(foot_pos.x) && Mathf.Round(goat_pos.y) == Mathf.Round(foot_pos.y))
            {
                Debug.Log("I hit the Goat");
            }
            else
            {
                Debug.Log("I missed the Goat");
            }

            //Play the stomp animation
            //if it is tell it that and have the goat play the stomped animation and start respawning
        }
    }
}