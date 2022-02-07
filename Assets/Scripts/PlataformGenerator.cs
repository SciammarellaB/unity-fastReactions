using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformGenerator : MonoBehaviour {

	public GameObject[] tilePrefab;
	public Vector3 instantiatePosition;
	public Transform[] prefabParent;
	public float tileLenght;
	public float tileNextPosY;
	public int selectedPlataform;


	void Start ()
	{
		tileLenght = 3.5f;
		selectedPlataform = 0;
		tileNextPosY = -4;

		for (int i = 0; i < 100; i++) 
		{
			instantiatePosition = new Vector3 (-7 + (i * tileLenght), tileNextPosY, 0);
			Instantiate (tilePrefab [selectedPlataform], instantiatePosition, Quaternion.identity, prefabParent [selectedPlataform]);
			tileNextPosY = -4;
			selectedPlataform = Random.Range (0, 2);
		}
	}
	

	void Update ()
	{
		
	}

}
