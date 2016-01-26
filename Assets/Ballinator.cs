using UnityEngine;
using System.Collections;


// TODO: Set up version control
// TODO: see if I can change colour of ball, and have it change colours automatically

public class Ballinator : MonoBehaviour
{
    private const int speed = 300;

    private Vector3 origPos; 

    private Rigidbody rb;
    private Score scoreScript;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        origPos = transform.position; // grab original co-ords for reset
        scoreScript = (Score)FindObjectOfType(typeof(Score));

        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        } 

        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        // start over if ball rolled off edge
        if (transform.position.y <= -15)
        { 
            transform.position = origPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            scoreScript.FellOff();
        }
    }
}