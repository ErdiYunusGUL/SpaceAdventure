using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();
    List<GameObject> usePlanets = new List<GameObject>();
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Planets");

        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];
            Color spriteColor = sRenderer.color;
            spriteColor.a = 0.5f;
            sRenderer.color = spriteColor;
            planet.name = sprites[i].name;
            sRenderer.sortingLayerName = "Planet";
            Vector2 pPosition = planet.transform.position;
            pPosition.x = -10;
            planet.transform.position = pPosition;
            planets.Add(planet);
        }
    }

    public void PlanetTransform(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float width = ScreenCalculator.instance.Width;

        //1.Region
        float xValue1 = Random.Range(0.0f, width);
        float yValue1 = Random.Range(refY,refY+height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1,yValue1);

        //2.Region
        float xValue2 = Random.Range(-width, 0.0f);
        float yValue2 = Random.Range(refY, refY + height);
        GameObject planet2 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue2, yValue2);
        //3.Region
        float xValue3 = Random.Range(-width, 0);
        float yValue3 = Random.Range(refY-height, refY );
        GameObject planet3 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue3, yValue3);
        //4.Region
        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY - height, refY);
        GameObject planet4 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue4, yValue4);
    }

    GameObject RandomPlanet()
    {
        if (planets.Count > 0)
        {
            int random;
            if (planets.Count == 1)
            {
                random = 0;
            }
            else
            {
               random = Random.Range(0, planets.Count - 1);
            }
            GameObject planet = planets[random];
            planets.Remove(planet);
            usePlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(usePlanets[i]);
            }
            usePlanets.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject planet = planets[random];
            planets.Remove(planet);
            usePlanets.Add(planet);
            return planet;
        }
    }
}
