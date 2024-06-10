using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Sprite[] musicIcons;
    
    public Button musicButton;

    

    // Start is called before the first frame update
    void Start()
    {
        if (Registrations.Register() == false)
        {
            Registrations.EasyValueSet(1);
        }

        if (Registrations.MusicOpenRegister() == false)
        {
            Registrations.MusicOpenValueSet(1);
        }
        MusicSettingsControl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HighScore()
    {
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        SceneManager.LoadScene(3);
    }

    public void Music()
    {
        if (Registrations.musicOpenValueGet() == 1)
        {
            Registrations.MusicOpenValueSet(0);
            MusicControl.instance.MusicPlay(false);
            musicButton.image.sprite = musicIcons[0]; 
        }
        else
        {
            Registrations.MusicOpenValueSet(1);
            MusicControl.instance.MusicPlay(true);
            musicButton.image.sprite = musicIcons[1];
        }
    }

    void MusicSettingsControl()
    {
        if (Registrations.musicOpenValueGet() == 1)
        {
            
            musicButton.image.sprite = musicIcons[1];
            MusicControl.instance.MusicPlay(true);
        }
        else
        {
            musicButton.image.sprite = musicIcons[0];
            MusicControl.instance.MusicPlay(false);
        }
    }
}
