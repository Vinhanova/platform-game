using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator enemyAnimator;

    public void PlayAnimation(string animationName)
    {
        enemyAnimator.Play(animationName);
    }
}
