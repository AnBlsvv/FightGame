using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    // which character the player chosen will appear in his position + enemy will appear in his position
    public void SelectCharacter()
    {
        GameObject playerOne = Instantiate(characterPrefabs[Random.Range(0,2)], new Vector3(60, 0, 22), Quaternion.Euler(0, 90, 0)) as GameObject;
        playerOne.name = "playerOne";
        GameObject playerTwo = Instantiate(characterPrefabs[Random.Range(0,2)], new Vector3(88, 0, 19), Quaternion.Euler(0, -90, 0)) as GameObject;
        playerTwo.name = "playerTwo";
    }
}
