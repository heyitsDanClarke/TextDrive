using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static GameMaster Instance;

    public int score;
    public int multiplier = 1;
    float highScore;
    Text scoreDisplay;
    Text highScoreDisplay;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
        highScoreDisplay = GameObject.Find("High Score").GetComponent<Text>();
    }

    private void Update()
    {
        score += multiplier;
        scoreDisplay.text = System.String.Format("{0:#,#}", Mathf.RoundToInt(score));
        if (score > highScore)
        {
            highScore = score;
            highScoreDisplay.text = System.String.Format("{0:#,#}", Mathf.RoundToInt(highScore));
        }
    }
}
