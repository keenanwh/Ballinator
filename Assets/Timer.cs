using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private TextMesh timerText;
    private float startTime;

    public void Reset()
    {
        startTime = Time.time;
        float currentTimer = 60;
        timerText = GetComponent<TextMesh>();
        timerText.text = currentTimer.ToString();
    }

	// Use this for initialization
	void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update ()
    {
        float timeLeft = (startTime + 60) - Time.time;
        timerText.text = timeLeft.ToString("0.0");
    }
}