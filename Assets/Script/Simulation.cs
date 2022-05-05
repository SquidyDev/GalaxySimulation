using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Simulation : MonoBehaviour
{
	List<GameObject> planetList = new List<GameObject>();
	PlanetGenerator planetGenerator;

	[SerializeField] Vector3 starDefaultImpulsion;

	
	private void Start()
	{
		planetGenerator = FindObjectOfType<PlanetGenerator>();

		planetGenerator.GeneratePlanets();

		foreach(GameObject planet in planetList) 
		{
			planet.GetComponent<Rigidbody>().AddForce(starDefaultImpulsion, ForceMode.VelocityChange);
		}

		planetList.Clear();
		planetList = planetGenerator.planetList;
	}

	private void Update()
	{
		DoSimulation();
	}

	void DoSimulation() 
	{
		for(int i = 0; i < planetList.Count; i++) 
		{
			GameObject currentPlanet = planetList[i];
			Rigidbody currentPlanetBody = currentPlanet.GetComponent<Rigidbody>();
			Vector3 forceSum = new Vector3(0, 0, 0);

			for(int j = 0; j < planetList.Count; j++) 
			{
				if (j == i) continue;
				GameObject planet = planetList[j];

				float distance = Vector3.Distance(currentPlanet.transform.position, planet.transform.position);
				float squareDistance = distance * distance;

				float force = ((currentPlanetBody.mass * planet.GetComponent<Rigidbody>().mass) / (squareDistance + 1));

				Vector3 vectorForce = force * (planet.transform.position - currentPlanet.transform.position);
				forceSum += vectorForce;
			}
			currentPlanetBody.AddForce(forceSum, ForceMode.Impulse);
		}
	}
	
}
