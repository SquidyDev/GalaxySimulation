using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlanetGenerator))]
public class PlanetGeneratorEditorScript : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		PlanetGenerator planetGenerator = (PlanetGenerator)target;

		if(GUILayout.Button("Generate Planets")) 
		{
			planetGenerator.Clear();

			planetGenerator.GeneratePlanets();
		}

		if (GUILayout.Button("Clear Planets"))
		{
			planetGenerator.Clear();
		}
	}
}
