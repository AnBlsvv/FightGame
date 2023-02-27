using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // When fight is start, then camera move to another position
    public void Update()
    {
        Vector3 new_position = new Vector3(68, 10, -4);
        transform.position = Vector3.Lerp(transform.position, new_position, 2.0f * Time.deltaTime);
        Quaternion new_rotation = Quaternion.Euler(10, 9, 2.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, new_rotation, 2.0f * Time.deltaTime);
    }
}
