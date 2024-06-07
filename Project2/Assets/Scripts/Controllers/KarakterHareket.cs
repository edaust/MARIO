using Assets.GameFolders.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//
public class KarakterHareket : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float ziplamaGucu = 10f;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Animator animator;

    public LayerMask groundLayer;
    bool isGrounded = false;
    float playerXScale;

    public bool isLadder, isClimbing;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerXScale = spriteRenderer.transform.localScale.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FailArea"))
            Events.onFail?.Invoke();
        
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    void Update()
    {
        Hareket();
        Zipla();
        Yon();
    }

    void Hareket()
    {
        float yatayHareket = Input.GetAxis("Horizontal");

        animator.SetFloat("MoveSpeed", Mathf.Abs(yatayHareket));

        float vertical = Input.GetAxis("Vertical");
        float dikeyHareket = 0;
        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
            dikeyHareket = 1 * hareketHizi;
            animator.SetBool("isClimbing", true);
        }
        else
        {
            dikeyHareket = rb.velocity.y;
            animator.SetBool("isClimbing", false);
        }
        
        rb.velocity = new(yatayHareket * hareketHizi, dikeyHareket);
    }

    void Zipla()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, .1f, groundLayer);
        isGrounded = hit.collider != null;

        //Yere indi
        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJump", false);
        }

        //sadece yerdeyken zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            animator.SetBool("isJump", true);

            isGrounded = false;
        }

        //düşüyor
        if (isGrounded == false && rb.velocity.y < 0)
            animator.SetBool("isFalling", true);
    }
    
    private void Yon()
    {
        Vector3 localScale = spriteRenderer.transform.localScale;

        var xScale = playerXScale;
        if (rb.velocity.x < 0)
            xScale = -playerXScale;

        if (rb.velocity.x != 0)
        {
            spriteRenderer.transform.localScale = new Vector3(xScale, localScale.y);
        }
    }
}

