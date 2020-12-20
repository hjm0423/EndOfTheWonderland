using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    float score = 0;
    Transform playertr;
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(HighScoreCheck());
    }

    IEnumerator HighScoreCheck()
    {
        while (true)
        {

            score = Mathf.Max(score, Mathf.Floor(playertr.position.y * 10) / 10);
            scoreText.text = "High Score : " + score;
            yield return null;
        }
    }

    
}
