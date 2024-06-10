using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject deadlyPlatformPrefab;
    public GameObject playerPrefab;
    

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformsPos;
    Vector2 playerPos;

    public float distanceBetweenPlatform;
    // Start is called before the first frame update
    void Start()
    {
        PlatformProduce();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            PlatformPlace();
        }
    }


    void PlatformProduce()
    {
        platformsPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformsPos, Quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Move = true;


        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformsPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Move = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().GoldOpen();
            }
            NextPlatformPosition();
        }
        GameObject deadlyPlatform = Instantiate(deadlyPlatformPrefab, platformsPos, Quaternion.identity);
        deadlyPlatform.GetComponent<Platform>().Move = true;
        platforms.Add(deadlyPlatform);
        NextPlatformPosition();
    }


    void PlatformPlace()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformsPos;
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Gold>().GoldClose();
                float randomGold = Random.Range(0.0f, 1.0f);
                if (randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().GoldOpen();
                }
            }
            NextPlatformPosition();
        }
    }

    void NextPlatformPosition()
    {
        platformsPos.y += distanceBetweenPlatform;
        float random = Random.Range(0.0f, 1.0f);
        if(random < 0.5f)
        {
            platformsPos.x = ScreenCalculator.instance.Width / 2;
        }
        else
        {
            platformsPos.x = -ScreenCalculator.instance.Width / 2;
        }
    }
}
