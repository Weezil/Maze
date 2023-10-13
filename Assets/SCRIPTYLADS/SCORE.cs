using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCORE : MonoBehaviour
{
    public static SCORE Instance;

    public Text scoreText;
    public Text livesText;

    int score = 0;
    int lives = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "POINTS: " + score.ToString();
        livesText.text = "LIVES: " + lives.ToString();
    }

    public void Awake()
    {
        score += 1;
        scoreText.text = "POINTS: " + score.ToString();
    }
}
