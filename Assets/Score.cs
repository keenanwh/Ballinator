using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    private int currentScore;
    private TextMesh scoreText;

    public void Reset()
    {
        currentScore = 0;
    }

    public void FellOff()
    {
        currentScore -= 2;
    }

    public void CollectedItem()
    {
        currentScore++;
    }

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<TextMesh>();
        scoreText.text = "0";
        Reset();
    }

    // Update is called once per frame
    void Update ()
    {
        scoreText.text = currentScore.ToString();
    }
}