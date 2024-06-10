using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Foots")
        {
            GetComponentInParent<Gold>().GoldClose();
            FindObjectOfType<Score>().GoldWin();
        }
    }
}
