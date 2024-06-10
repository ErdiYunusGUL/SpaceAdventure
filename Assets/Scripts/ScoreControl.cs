using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text easyScore, easyGold, normalScore, normalGold, hardScore, hardGold;
    
    
    // Start is called before the first frame update
    void Start()
    {
        easyScore.text = "Score: " + Registrations.EasyScoreValueGet();
        easyGold.text = " X " + Registrations.EasyGoldValueGet();

        normalScore.text = "Score: " + Registrations.NormalScoreValueGet();
        normalGold.text = " X " + Registrations.NormalGoldValueGet();

        hardScore.text = "Score: " + Registrations.HardScoreValueGet();
        hardGold.text = " X " + Registrations.HardGoldValueGet();
    }



    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
