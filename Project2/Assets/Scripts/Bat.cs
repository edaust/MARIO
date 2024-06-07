using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject dieEffect;

    public int hight = 2;
    private float startYPos;
    public AudioSource audioSource;

    private void Start()
    {
        startYPos = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, startYPos + Mathf.PingPong(Time.time * 2, hight),
            transform.position.z); //move on y axis only
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Acorn"))
        {
            // die 
            Destroy(Instantiate(dieEffect, spriteRenderer.transform.position, Quaternion.identity), 1);
            Vector3 jumpDirection = (transform.position - other.transform.position).normalized;
            Destroy(other.gameObject);
            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody2D>().AddForce((jumpDirection * 500) + (Vector3.up * 250));
            GetComponent<Rigidbody2D>().gravityScale = 1;
            spriteRenderer.color = Color.red;
            audioSource.Play();
            
            Destroy(gameObject, 3f);
        }
    }
}