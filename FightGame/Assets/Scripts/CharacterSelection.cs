using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
   // We have two buttons whith characters
    public int selectedCharacter = 0;
    public GameObject[] characterPrefabs;

    public void PurpleDragon()
    {
        selectedCharacter = 1;
    }

    public void GoldDragon()
    {
        selectedCharacter = 0;
    }
    // which character the player chosen will appear in his position + enemy will appear in his position
    public void SelectCharacter()
    {
        GameObject player = Instantiate(characterPrefabs[selectedCharacter], new Vector3(88, 0, 19), Quaternion.Euler(0, -90, 0)) as GameObject;
        player.name = "player";
        GameObject enemy = Instantiate(characterPrefabs[Random.Range(0,2)], new Vector3(60, 0, 22), Quaternion.Euler(0, 90, 0)) as GameObject;
        enemy.name = "enemy";
    }
}
