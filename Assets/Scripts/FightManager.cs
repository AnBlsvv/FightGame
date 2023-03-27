using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightManager : MonoBehaviour
{
    private int healthPlayerOne = 300;
    private int healthPlayerTwo = 300;
    public TextMeshProUGUI healthPlayerOneText; // changing count health player one
    public TextMeshProUGUI healthPlayerTwoText; // changing count health player two
    public TextMeshProUGUI[] playerOneSkills;
    public TextMeshProUGUI[] playerTwoSkils;
    public TextMeshProUGUI winSkill;
    public TextMeshProUGUI winner;
    private List<string> skills = new List<string>() {"fire", "water", "ground", "wind", "magic", "ice"};
    private GameObject playerOne;
    private GameObject playerTwo;
    public GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
        // give skill to characters
        for(int i = 0; i < 3; i++)
        {
            int randomPlayer = Random.Range(0,skills.Count);
            playerTwoSkils[i].text = skills[randomPlayer];
            skills.Remove(skills[randomPlayer]);

            int random_enemy = Random.Range(0,skills.Count);
            playerOneSkills[i].text = skills[random_enemy];
            skills.Remove(skills[random_enemy]);
            
        }
        // show in UI
        healthPlayerTwoText.text = healthPlayerTwo.ToString();
        healthPlayerOneText.text = healthPlayerOne.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerOne = GameObject.Find("playerOne");
        playerTwo = GameObject.Find("playerTwo");

        // which button is pressed, that player hits and start animation
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(healthPlayerOne > 0 && healthPlayerTwo > 0)
            {
                playerTwo.GetComponent<AnimationControl>().ScreamAnimation();
                Invoke("PlayerOneGetHit", 0.7f); 
            }   
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(healthPlayerOne > 0 && healthPlayerTwo > 0)
            {
                playerTwo.GetComponent<AnimationControl>().AttackAnimation();
                Invoke("PlayerOneGetHit", 0.7f);
            }    
        }
        if(Input.GetKeyDown(KeyCode.D))
        { 
            if(healthPlayerTwo > 0 && healthPlayerOne > 0){
               playerOne.GetComponent<AnimationControl>().ScreamAnimation();
                Invoke("PlayerTwoGetHit", 0.7f); 
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        { 
            if(healthPlayerTwo > 0 && healthPlayerOne > 0){
               playerOne.GetComponent<AnimationControl>().AttackAnimation();
                Invoke("PlayerTwoGetHit", 0.7f); 
            }
        }
    }

    public void PlayerOneGetHit()
    { 
        healthPlayerOne -= Random.Range(5,50);
        if(healthPlayerOne <= 0)
        {
            healthPlayerOne = 0;
            playerOne.GetComponent<AnimationControl>().DieAnimation();
            // get one random skill from the loser
            winSkill.text = playerOneSkills[Random.Range(0,3)].text;
            winner.text = "Player Two";
            winMenu.SetActive(true);
        }
        else playerOne.GetComponent<AnimationControl>().GetHitAnimation();
        healthPlayerOneText.text = healthPlayerOne.ToString();
    }

    public void PlayerTwoGetHit()
    {
        healthPlayerTwo -= Random.Range(5,50);
        if(healthPlayerTwo <= 0)
        {
            healthPlayerTwo = 0;
            playerTwo.GetComponent<AnimationControl>().DieAnimation();
            // get one random skill from the loser
            winSkill.text = playerTwoSkils[Random.Range(0,3)].text;
            winner.text = "Player One";
            winMenu.SetActive(true);
        }
        else playerTwo.GetComponent<AnimationControl>().GetHitAnimation();
        healthPlayerTwoText.text = healthPlayerTwo.ToString();
    }
}
