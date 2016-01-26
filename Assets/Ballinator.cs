using UnityEngine;
using System.Collections;


// TODO: see if I can change colour of ball, and have it change colours automatically

public class Ballinator : MonoBehaviour
{
    public void StartGame()
    {
        // grab original co-ords to be able to reset back to them
        _origPos = transform.position;
        _allowMovement = true;
    }

    public void StopGame()
    {
        _allowMovement = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void Start ()
    {
        // used to update score
        _scoreScript = (Score)FindObjectOfType(typeof(Score));

        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();

        StartGame();
    }

    public void Update()
    {
        // change the tilt of the plane every period
        if (Time.time > _nextChangeTiltTime)
        {
            _nextChangeTiltTime += _period;
            UpdateColor();
        }

        if (_allowMovement)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
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
        }

        // start over if ball rolled off edge
        if (transform.position.y <= -15)
        { 
            transform.position = _origPos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            _scoreScript.FellOff();
        }

        rend.material.color = Color.Lerp(rend.material.color, _targetColor, colorChangeSpeed * Time.deltaTime);
    }

    // Change the target color of the ball
    private void UpdateColor()
    {
        _targetColor = new Color(Random.value, Random.value, Random.value);
    }

    private Vector3 _origPos;
    private Score _scoreScript;
    private float _nextChangeTiltTime = 0.0f;
    private float _period = 1.0f;
    private Color _targetColor = Color.red;
    private bool _allowMovement = false;

    private Rigidbody rb;
    private Renderer rend;

    private const int speed = 300;
    private const int colorChangeSpeed = 5;
}