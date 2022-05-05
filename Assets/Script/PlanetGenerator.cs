using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] Transform planetParent;
    [SerializeField] int planetAmount;
    [SerializeField] float planetMass;
    [SerializeField] GameObject planetPrefab;

    [SerializeField] float galaxyDiameter;
    [SerializeField] float galaxyThickness;

    public List<GameObject> planetList = new List<GameObject>();

    public void GeneratePlanets() 
    {
        Clear();

        for (int i = 0; i < planetAmount; i++)
        {
            GameObject planet = Instantiate(planetPrefab);

            planet.transform.position = Random.insideUnitSphere * galaxyDiameter;
            planet.transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z * galaxyThickness / galaxyDiameter);
            planet.transform.parent = planetParent;
            planet.name = $"Planet_{i}";

            planet.AddComponent<Rigidbody>();
            planet.GetComponent<Rigidbody>().mass = planetMass;
            planet.GetComponent<Rigidbody>().useGravity = false;

            planetList.Add(planet);
        }
    }

    public void Clear() 
    {
        foreach (GameObject planet in planetList)
        {
            DestroyImmediate(planet);
        }

        planetList.Clear();
    }
}
