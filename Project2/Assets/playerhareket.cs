using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhareket : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    float speedAmount = 5f;
    float JumpAmount = 3f;

    private void Start()
    {
        rgb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * JumpAmount, ForceMode2D.Impulse);      ;
        }
        if(Input.GetAxisRaw("Horizontal")== -1)
        {
            transform.rotation= Quaternion. Euler(0f,180f,0f);
        }
        else if(Input.GetAxisRaw("Horizontal")==1)
        {
            transform.rotation=Quaternion.Euler(0f,0f,0f);
        }
    }
}
