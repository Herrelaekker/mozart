using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public int curHealth;
    public int maxHealth;

    public float invincibilityLength;
    private float invincibilityCounter;

    private Renderer playerRenderer;
    private Renderer playerHeadRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool facingRight;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerRenderer = GetComponent<Renderer>();
        playerHeadRenderer = GameObject.Find("Head").GetComponent<Renderer>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //bevæger sig hele tiden anpå moveInput
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        //isGrounded er hvis der er Ground under en
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //Hvis man går til højre, vend til højre | Hvis man går til venstre, vend til venstre
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }

        //Hvis man bevæger sig på ground -> Gå animation, ellers Idle animation
        if (isGrounded == true && moveInput != 0)
        {
            anim.SetInteger("state", 1);
        }
        else
            anim.SetInteger("state", 0);

        //Hvis man trykker hop, nede på jorden -> så hopper man + hoppe animation
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            anim.SetInteger("state", 2);
        }

        //Hvis man hopper i forvejen og holder hoppe knappen nede -> så fortsætter man med at ryge op ad, til timeren ryger ud.
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                anim.SetInteger("state", 2);
            }
            else
            {
                isJumping = false;
            }
        }

        //Hvis man har givet slip på knappen -> så ryger man ned igen
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        //Hvis man er i luften og er færdig med at hoppe -> så falder man
        if (isJumping == false && isGrounded == false)
        {
            anim.SetInteger("state", 3);
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();
        }

        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                playerHeadRenderer.enabled = !playerHeadRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <=0)
            {
                playerRenderer.enabled = true;
                playerHeadRenderer.enabled = true;
            }
        }

    }

    void Die()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.name);
    }

    public void TakeDamge( int dmg)
    {
        if (invincibilityCounter <= 0)
        {
            curHealth -= dmg;

            invincibilityCounter = invincibilityLength;
            playerRenderer.enabled = false;
            playerHeadRenderer.enabled = false;
            flashCounter = flashLength;
        }
    }
}
