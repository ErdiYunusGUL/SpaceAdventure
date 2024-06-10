using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
   public GameObject gold;
    
    public void GoldOpen()
    {
        gold.SetActive(true);
    }

    public void GoldClose()
    {
        gold.SetActive(false);
    }
}
