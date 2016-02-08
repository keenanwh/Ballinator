using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public void Reset()
    {
        // used to update score
        _ballinatorScript = (Ballinator)FindObjectOfType(typeof(Ballinator));

        startTime = Time.time;
        float currentTimer = TimePerRound;
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
        float timeLeft = (startTime + TimePerRound) - Time.time;

        if (timeLeft < 0)
        {
            timeLeft = 0;
            _ballinatorScript.StopGame();
        }
        else
            timerText.text = timeLeft.ToString("0.0");
    }

    private const int TimePerRound = 30;
    private TextMesh timerText;
    private float startTime;
    private Ballinator _ballinatorScript;
}