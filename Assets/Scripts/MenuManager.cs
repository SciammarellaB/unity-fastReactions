using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void LevelSelector(int level)
    {
        switch (level)
        {
            case 1: SceneManager.LoadScene(level);

                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
