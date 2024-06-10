using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public GameObject board;
    public GameObject menuButton;
    public GameObject Slider;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOpen();
    }


    public void GameFinish()
    {
        FindObjectOfType<AudioControl>().GameOverSound();
        gameOverPanel.SetActive(true);
        FindObjectOfType<Score>().GameOver();
        FindObjectOfType<PlayerControllers>().GameOver();
        FindObjectOfType<CameraMove>().GameOver();
        UIClose();
    }

    public void MainMenuBack()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    void UIOpen()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        board.SetActive(true);
        menuButton.SetActive(true);
        Slider.SetActive(true);
    }
    void UIClose()
    {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        board.SetActive(false);
        menuButton.SetActive(false);
        Slider.SetActive(false);
    }
}
