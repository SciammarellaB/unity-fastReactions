using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject player;
    public float cameraSpeed;
    public int cameraFocus;

    void Start()
    {
        cameraSpeed = 3;
        cameraFocus = 5;
    }


    void Update()
    {
        CameraPosition();
    }

    void CameraPosition()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
