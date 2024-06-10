using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyButton, normalButton, hardButton; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (Registrations.EasyValueGet() == 1)
        {
            easyButton.interactable = false;
            normalButton.interactable = true;
            hardButton.interactable = true;
        }

        if (Registrations.NormalValueGet() == 1)
        {
            easyButton.interactable = true;
            normalButton.interactable = false;
            hardButton.interactable = true;
        }
        if (Registrations.HardValueGet() == 1)
        {
            easyButton.interactable = true;
            normalButton.interactable = true;
            hardButton.interactable = false;
        }
    }

    public void OptionSelected(string level)
    {
        switch (level)
        {
            case "easy":
                Registrations.EasyValueSet(1);
                Registrations.NormalValueSet(0);
                Registrations.HardValueSet(0);
                easyButton.interactable = false;
                normalButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "normal":
                Registrations.EasyValueSet(0);
                Registrations.NormalValueSet(1);
                Registrations.HardValueSet(0);
                easyButton.interactable = true;
                normalButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Registrations.EasyValueSet(0);
                Registrations.NormalValueSet(0);
                Registrations.HardValueSet(1);
                easyButton.interactable = true;
                normalButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                break;
        }
    }


   public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
