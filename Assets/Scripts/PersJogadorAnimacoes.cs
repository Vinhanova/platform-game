using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersJogadorAnimacoes : MonoBehaviour
{
    private Animator playerAnimator;

    public void PlayAnimation(string animationName)
    {
        playerAnimator.Play(animationName);
    }
}
