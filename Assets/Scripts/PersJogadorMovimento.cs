using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PersJogadorMovimento : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    float mx;
    private Animator anim;

    public bool canMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {

            #region Player Flip

            Vector3 characterScale = transform.localScale;
            if (mx < 0)
            {
                characterScale.x = -0.2189753f;
            }
            if (mx > 0)
            {
                characterScale.x = 0.2189753f;
            }
            transform.localScale = characterScale;

            #endregion


            #region Animations + Jump Trigger

            if (IsGrounded())
            {
                anim.SetBool("isJumping", false);

                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetTrigger("takeOf");
                    Jump();
                }
                else
                {
                    if (mx == 0)
                    {
                        anim.SetBool("isRunning", false);
                    }
                    else
                    {
                        anim.SetBool("isRunning", true);
                    }
                }
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", true);
            }

            #endregion

        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
            rb.velocity = movement;
        }
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }



    /*
    private Rigidbody2D playerRb2d;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    private bool canDoubleJump;
    private Image[] vidas;
    [SerializeField]

    public int vida = 3;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);

    }
    private void HandleMovement(float horizontal)
    {
        if(horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
             anim.SetBool("isRunning", true);
        }

        playerRb2d.velocity = new Vector2(horizontal * movementSpeed, playerRb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            if (grounded)
            {
                playerRb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = false;
                grounded = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    playerRb2d.velocity = new Vector2(playerRb2d.velocity.x, 0);
                    playerRb2d.AddForce(Vector2.up * jumpPower / 1.75f);
                }
            }
        }
    }

    public bool IsGrounded()
    {
        if (collision.gameObject.tag == "plataforma")
        {
            grounded = true;
            canDoubleJump = false;
        }
    }

    /* private void SetIsRunning(bool value)
    {
        if(value != isRunning)
        {
            if(value)
            {
                jogadorAnim.PlayAnimation("Running");
            }
            else
            {
                jogadorAnim.PlayAnimation("Idle");
            }
        }
        isRunning = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            grounded = true;
            canDoubleJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Limite")
        {
            Debug.Log("Saiu fora do mapa!");
            //tirar vidas ao morrer
            TirarVida();
            vida -= 1;
        }
    }

     public void TirarVida()
    {
        if (vida == 0)
        {
            GameOver();
        }
        for (int i = 0; i < vidas.Length; i++)
        {
            if (i < vida)
            {
                //Set active é a checkbox ao lado do nome do elemento
                vidas[i].gameObject.SetActive(true);
            }
            else
            {
                vidas[i].gameObject.SetActive(false);
                Debug.Log("Perde Vida!");
            }
        }

    } 

    //Função ao morrer
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Dead");
    }

    */
}
