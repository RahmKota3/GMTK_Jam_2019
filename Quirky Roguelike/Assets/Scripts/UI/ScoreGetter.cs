using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int highScore;

    // Start is called before the first frame update

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
