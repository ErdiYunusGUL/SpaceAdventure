using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registrations 
{
    public static string easy = "easy";
    public static string normal = "normal";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string normalScore = "normalScore";
    public static string hardScore = "hardScore";

    public static string easyGold = "easyGold";
    public static string normalGold = "normalGold";
    public static string hardGold = "hardGold";

    public static string musicOpen = "musicOpen";

    public static void EasyValueSet(int easy)
    {
        PlayerPrefs.SetInt(Registrations.easy, easy);
    }

    public static int EasyValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.easy);
    }
    public static void NormalValueSet(int normal)
    {
        PlayerPrefs.SetInt(Registrations.normal, normal);
    }
    public static int NormalValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.normal);
    }
    public static void HardValueSet(int hard)
    {
        PlayerPrefs.SetInt(Registrations.hard, hard);
    }
    public static int HardValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.hard);
    }

    public static void EasyScoreValueSet(int easyScore)
    {
        PlayerPrefs.SetInt(Registrations.easyScore, easyScore);
    }
    public static int EasyScoreValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.easyScore);
    }
    public static void NormalScoreValueSet(int normalScore)
    {
        PlayerPrefs.SetInt(Registrations.normalScore, normalScore);
    }
    public static int NormalScoreValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.normalScore);
    }
    public static void HardScoreValueSet(int hardScore)
    {
        PlayerPrefs.SetInt(Registrations.hardScore, hardScore);
    }
    public static int HardScoreValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.hardScore);
    }




    public static void EasyGoldValueSet(int easyGold)
    {
        PlayerPrefs.SetInt(Registrations.easyGold, easyGold);
    }
    public static int EasyGoldValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.easyGold);
    }
    public static void NormalGoldValueSet(int normalGold)
    {
        PlayerPrefs.SetInt(Registrations.normalGold, normalGold);
    }
    public static int NormalGoldValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.normalGold);
    }
    public static void HardGoldValueSet(int hardGold)
    {
        PlayerPrefs.SetInt(Registrations.hardGold, hardGold);
    }
    public static int HardGoldValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.hardGold);
    }



    public static void MusicOpenValueSet(int musicOpen)
    {
        PlayerPrefs.SetInt(Registrations.musicOpen, musicOpen);
    }
    public static int musicOpenValueGet()
    {
        return PlayerPrefs.GetInt(Registrations.musicOpen);
    }




    public static bool Register()
    {
        if (PlayerPrefs.HasKey(Registrations.easy) || PlayerPrefs.HasKey(Registrations.normal) || PlayerPrefs.HasKey(Registrations.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool MusicOpenRegister()
    {
        if (PlayerPrefs.HasKey(Registrations.musicOpen) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
