using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeManager : MonoBehaviour {

	public Transform whiteParent;
	public Transform blackParent;
	public GameObject[] whiteTiles;
	public GameObject[] blackTiles;

	void Startup()
	{
		
	}

	void Start () 
	{
		whiteTiles = GameObject.FindGameObjectsWithTag ("White");
		blackTiles = GameObject.FindGameObjectsWithTag ("Black");


	}
	
	void Update () 
	{
		
	}
}
