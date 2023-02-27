using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightManager : MonoBehaviour
{
    private int health_player = 300;
    private int health_enemy = 300;

    public TextMeshProUGUI health_player_text; // changing count health player
    public TextMeshProUGUI health_enemy_text; // changing count health enemy

    public TextMeshProUGUI[] player_perks;
    public TextMeshProUGUI[] enemy_perks;

    public TextMeshProUGUI win_perk;
    public TextMeshProUGUI winner;

    private List<string> perks = new List<string>() {"fire", "water", "ground", "wind", "magic", "ice"};

    private GameObject player;
    private GameObject enemy;

    public GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
        // give perks to characters
        for(int i = 0; i < 3; i++)
        {
            int random_player = Random.Range(0,perks.Count);
            player_perks[i].text = perks[random_player];
            perks.Remove(perks[random_player]);

            int random_enemy = Random.Range(0,perks.Count);
            enemy_perks[i].text = perks[random_enemy];
            perks.Remove(perks[random_enemy]);
            
        }
        // show in UI
        health_player_text.text = health_player.ToString();
        health_enemy_text.text = health_enemy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        enemy = GameObject.Find("enemy");

        // which button is pressed, that player hits and start animation

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(health_enemy > 0 && health_player > 0)
            {
                player.GetComponent<AnimationControl>().Scream_Anim();
                Invoke("EnemyGetHit", 0.7f); 
            }   
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(health_enemy > 0 && health_player > 0)
            {
                player.GetComponent<AnimationControl>().Attack_Anim();
                Invoke("EnemyGetHit", 0.7f);
            }    
        }
        if(Input.GetKeyDown(KeyCode.A))
        { 
            if(health_player > 0 && health_enemy > 0){
               enemy.GetComponent<AnimationControl>().Scream_Anim();
                Invoke("PlayerGetHit", 0.7f); 
            }
        }
        if(Input.GetKeyDown(KeyCode.Z))
        { 
            if(health_player > 0 && health_enemy > 0){
               enemy.GetComponent<AnimationControl>().Attack_Anim();
                Invoke("PlayerGetHit", 0.7f); 
            }
        }
    }

    public void PlayerGetHit()
    {
        health_player -= Random.Range(5,50);
        if(health_player <= 0)
        {
            health_player = 0;
            player.GetComponent<AnimationControl>().Die_Anim();
            // get one random perk from the loser
            win_perk.text = player_perks[Random.Range(0,3)].text;
            winner.text = "Enemy";
            winMenu.SetActive(true);
        }
        else player.GetComponent<AnimationControl>().GetHit_Anim();
        health_player_text.text = health_player.ToString();
    }
    public void EnemyGetHit()
    { 
        health_enemy -= Random.Range(5,50);
        if(health_enemy <= 0)
        {
            health_enemy = 0;
            enemy.GetComponent<AnimationControl>().Die_Anim();
            // get one random perk from the loser
            win_perk.text = enemy_perks[Random.Range(0,3)].text;
            winner.text = "Player";
            winMenu.SetActive(true);
        }
        else enemy.GetComponent<AnimationControl>().GetHit_Anim();
        health_enemy_text.text = health_enemy.ToString();
    }
}
