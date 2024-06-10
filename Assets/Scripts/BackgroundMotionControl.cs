using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMotionControl : MonoBehaviour
{
    float backGroundLocation;
    float distance = 10.24f;


    // Start is called before the first frame update
    void Start()
    {
        backGroundLocation = transform.position.y;
        FindObjectOfType<Planet>().PlanetTransform(backGroundLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if (backGroundLocation + distance < Camera.main.transform.position.y)
        {
            BackgroundPlace();
        }
    }

    void BackgroundPlace()
    {
        backGroundLocation += (distance * 2);
        FindObjectOfType<Planet>().PlanetTransform(backGroundLocation);
        Vector2 newPosition = new Vector2(0, backGroundLocation);
        transform.position = newPosition;
    }
}
