#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]

public class Teste : EditorWindow
{
	PlataformGenerator pG;
	GameObject camObj;
	public Object whitetilePrefab;
	public Object blacktilePrefab;
	public Object selectedObject;
    public Object lastPlatform;
    public Vector3 instantiatePosition;
	public GameObject whitePrefabParent;
	public GameObject blackPrefabParent;
	public GameObject selectedParent;
  	public float tileLenght;
	public float tileNextPosY;
	public float tileMaxYDist;
	public int selectedPlataform;
	public string whiteParentString;
	public string blackParentString;
	public int platformNumber;

	[MenuItem("Window/WorldGen")]

	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(Teste));
	}
    
	void OnGUI()
	{
		GUILayout.Label ("Generate the world", EditorStyles.boldLabel);
		whitetilePrefab = EditorGUILayout.ObjectField("White Tile Prefab",whitetilePrefab,typeof(Object),true);
		blacktilePrefab = EditorGUILayout.ObjectField("Black Tile Prefab",blacktilePrefab,typeof(Object),true);
        lastPlatform = EditorGUILayout.ObjectField("Last Tile Prefab", lastPlatform, typeof(Object), true);
		whiteParentString = EditorGUILayout.TextField ("White Parent Tag", whiteParentString);
		blackParentString = EditorGUILayout.TextField ("Black Parent Tag", blackParentString);
		instantiatePosition = EditorGUILayout.Vector3Field ("Initial Position", instantiatePosition);
		platformNumber = EditorGUILayout.IntField ("Platform Numbers", platformNumber);
		tileLenght = EditorGUILayout.FloatField ("Tile Lenght", tileLenght);
	
		if (GUILayout.Button ("Generate")) 
		{
			Generate ();
		}
	}

	void Generate()
	{
        selectedPlataform = 1;
        tileMaxYDist = 1;
		whitePrefabParent = GameObject.FindGameObjectWithTag (whiteParentString);
		blackPrefabParent = GameObject.FindGameObjectWithTag (blackParentString);
	
		for (int i = 0; i < platformNumber; i++) 
		{
			tileNextPosY = Random.Range(-1,2) * tileMaxYDist;
		
			if (selectedPlataform == 0) 
			{
				selectedObject = whitetilePrefab;
				selectedParent = whitePrefabParent;
			}

			if (selectedPlataform == 1) 
			{
				selectedObject = blacktilePrefab;
				selectedParent = blackPrefabParent;
			}

			instantiatePosition = new Vector3 (-7 + (i * tileLenght), tileNextPosY, 0);
			Instantiate (selectedObject, instantiatePosition, Quaternion.identity,selectedParent.transform);
			selectedPlataform = Random.Range (0, 2);

            Debug.Log(i);

            if (i == platformNumber -1) //Used to place the last platform
            {
                i++;
                instantiatePosition = new Vector3(-7 + (i * tileLenght), tileNextPosY, 0);
                Instantiate(lastPlatform, instantiatePosition, Quaternion.identity);
                
            }
        }
	}
}
#endif
