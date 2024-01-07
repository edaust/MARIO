using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerXScale = spriteRenderer.transform.localScale.x;
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
        rb.velocity = new (yatayHareket * hareketHizi, rb.velocity.y);

        animator.SetFloat("MoveSpeed", Mathf.Abs(yatayHareket));
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

        spriteRenderer.transform.localScale = new Vector3(xScale, localScale.y);
    }

}

