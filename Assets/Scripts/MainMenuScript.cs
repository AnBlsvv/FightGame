using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public Camera cam;
    public GameObject fighingObjects;

    // Start is called before the first frame update
    void Start()
    {
        // disable game objects, which we dont need when start the game
        cam.GetComponent<MoveCameraRight>().enabled = false;
        fighingObjects.SetActive(false);
    }
    
    // button start game, show fighting objects
    public void StartGame()
    {
        mainMenu.SetActive(false);
        cam.GetComponent<MoveCameraRight>().enabled = true;
        fighingObjects.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
