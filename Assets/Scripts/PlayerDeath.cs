using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator enemyAnim;
    private Animator playerAnim;

    private PersJogadorMovimento playerMovement;

    private bool isAlive;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerMovement = GetComponent<PersJogadorMovimento>();
        isAlive = true;
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    isAlive = false;
                    playerMovement.canMove = false;
                    enemyAnim = collision.gameObject.GetComponentInParent<Animator>();
                    enemyAnim.SetTrigger("Atack");
                    playerAnim.SetTrigger("Dead");
                    yield return new WaitForSeconds(1);
                    Destroy(gameObject);
                    LevelManager.instance.Respawn();
                    playerMovement.canMove = true;
                    isAlive = true;
                    break;

                case "DeadlyObjects":
                    isAlive = false;
                    playerMovement.canMove = false;
                    playerAnim.SetTrigger("Dead");
                    yield return new WaitForSeconds(1);
                    Destroy(gameObject);
                    LevelManager.instance.Respawn();
                    playerMovement.canMove = true;
                    isAlive = true;
                    break;

                case "Doors":
                    LevelManager.instance.LevelChange();
                    break;
            }
    }
}
