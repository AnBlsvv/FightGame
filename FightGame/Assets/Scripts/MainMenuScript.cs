using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    private GameObject baker_house;
    public Camera cam;
    private GameObject fighing_objects;

    // Start is called before the first frame update
    void Start()
    {
        // disable game objects, which we dont need when start the game
        mainMenu.SetActive(false);
        cam.GetComponent<MoveCameraRight>().enabled = false;
        fighing_objects = GameObject.Find("FightingObjects");
        fighing_objects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this script is attach to house and this func starts when player press on house
    void OnMouseDown()
    {
        mainMenu.SetActive(true); 
    }
    // button start game, show fighting objects
    public void StartGame()
    {
        mainMenu.SetActive(false);
        cam.GetComponent<MoveCameraRight>().enabled = true;
        fighing_objects.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
