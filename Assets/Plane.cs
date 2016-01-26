using UnityEngine;
using System.Collections;
using UnityEditor;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
           
    }
	
	// Update is called once per frame
	void Update ()
	{
        // change the tilt of the plane every period
	    if (Time.time > _nextChangeTiltTime)
	    {
	        _nextChangeTiltTime += _period;
            UpdatePlaneTilt();
	    }

        // smoothly change tilt of plane based to targetRotation based on time
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _speed * Time.deltaTime);
    }

    // 
    void UpdatePlaneTilt()
    {
        // plane tilt can be up to maxTilt on both axes
        float tiltAroundZ = Input.GetAxis("Horizontal") * Random.Range(-MaxTiltAngle, MaxTiltAngle);
        float tiltAroundX = Input.GetAxis("Horizontal") * Random.Range(-MaxTiltAngle, MaxTiltAngle);
        _targetRotation = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ); // converts x, y, z tilt to quaternion rotation
    }

    private int _speed = 1;
    private float _nextChangeTiltTime = 0.0f;
    private float _period = 1.0f;
    private Quaternion _targetRotation;

    private const float MaxTiltAngle = 15.0f;
}