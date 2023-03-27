using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Animation Control Script
public class AnimationControl : MonoBehaviour
{
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void ScreamAnimation()
    {
        playerAnimator.Play("Scream");
    }

    public void AttackAnimation()
    {
        playerAnimator.Play("Basic Attack");
    }

    public void GetHitAnimation()
    {
        playerAnimator.Play("Get Hit");
    }

    public void DieAnimation()
    {
        playerAnimator.Play("Die");
    }
}
