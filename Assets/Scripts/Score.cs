using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    int score;
    int highScore;
    int gold;
    int highGold;
    bool scorePoints = true;
    
    public Text scoreText;
    public Text goldText;

    public Text gameOverScoreText;
    public Text gameOverGoldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "X " + gold;
    }

    // Update is called once per frame
    void Update()
    {
        if (scorePoints)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Puan: " + score;
        }
        
    }

    public void GoldWin()
    {
        FindObjectOfType<AudioControl>().GoldSound();
        gold++;
        goldText.text = "X " + gold;
    }


    public void GameOver()
    {
        if (Registrations.EasyValueGet() == 1 )
        {
            highScore = Registrations.EasyScoreValueGet();
            highGold = Registrations.EasyGoldValueGet();
            if (score > highScore)
            {
                Registrations.EasyScoreValueSet(score);
            }

            if (gold > highGold)
            {
                Registrations.EasyGoldValueSet(gold);
            }
        }

        if (Registrations.NormalValueGet() == 1)
        {
            highScore = Registrations.NormalScoreValueGet();
            highGold = Registrations.NormalGoldValueGet();
            if (score > highScore)
            {
                Registrations.NormalScoreValueSet(score);
            }

            if (gold > highGold)
            {
                Registrations.NormalGoldValueSet(gold);
            }
        }


        if (Registrations.HardValueGet() == 1)
        {
            highScore = Registrations.HardScoreValueGet();
            highGold = Registrations.HardGoldValueGet();
            if (score > highScore)
            {
                Registrations.HardScoreValueSet(score);
            }

            if (gold > highGold)
            {
                Registrations.HardGoldValueSet(gold);
            }
        }
        scorePoints = false;
        gameOverScoreText.text = "Score: " + score;
        gameOverGoldText.text = " X " + gold;
    }
}
