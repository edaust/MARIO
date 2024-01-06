using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float ziplamaGucu = 10f;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Hareket();
        Zipla();
    }

    void Hareket()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        Vector2 yeniHiz = new Vector2(yatayHareket * hareketHizi, rb.velocity.y);
        rb.velocity = yeniHiz;

        animator.SetFloat("Hareket", Mathf.Abs(yatayHareket));
    }

    void Zipla()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            animator.SetBool("Ziplama", true);
        }
        else
        {
            animator.SetBool("Ziplama", false);
        }
    }
}

