using UnityEngine;
using System.Collections;
using UnityEditor;

public class Plane : MonoBehaviour {

    public void StartMovement()
    {
        _allowMovement = true;
    }

    public void StopMovement()
    {
        _allowMovement = false;
        transform.position = _origPos;
        transform.rotation = _origRot;
    }

    // Use this for initialization
    void Start ()
    {
        // grab original co-ords to be able to reset back to them
        _origPos = transform.position;

    }

    // Update is called once per frame
    void Update ()
	{
        // Debug.Log("plane update() entry");
        // change the tilt of the plane every period
	    if (Time.time > _nextChangeTiltTime)
	    {
	        _nextChangeTiltTime += _period;
            UpdatePlaneTilt();
	    }

        // smoothly change tilt of plane based to targetRotation based on time
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _speed * Time.deltaTime);
    }

    // Change the target tilt of the plane
    void UpdatePlaneTilt()
    {
        Debug.Log("plane UpdatePlaneTilt() entry");
        // plane tilt can be up to maxTilt on both axes
        float tiltAroundX = Random.Range(-MaxTiltAngle, MaxTiltAngle);
        float tiltAroundZ = Random.Range(-MaxTiltAngle, MaxTiltAngle);
        _targetRotation = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ); // converts x, y, z tilt to quaternion rotation
    }

    private int _speed = 1;
    private float _nextChangeTiltTime = 0.0f;
    private float _period = 1.0f;
    private Quaternion _targetRotation;

    private const float MaxTiltAngle = 25.0f;
    private bool _allowMovement = true;
    private Vector3 _origPos;
    private Quaternion _origRot;
}
