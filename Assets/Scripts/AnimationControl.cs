using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Animation Control Script
public class AnimationControl : MonoBehaviour
{
    private Animator player_animator;

    // Start is called before the first frame update
    void Start()
    {
        player_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Scream_Anim()
    {
        player_animator.Play("Scream");
    }

    public void Attack_Anim()
    {
        //Fireball Shoot
        player_animator.Play("Basic Attack");
    }

    public void GetHit_Anim()
    {
        player_animator.Play("Get Hit");
    }

    public void Die_Anim()
    {
        player_animator.Play("Die");
    }
}
