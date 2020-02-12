using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    private Rigidbody2D rb;
    Vector2 v = new Vector2(0, 0);
    int jumpTimer = 150;
    private float moveSmooth = 0.2f;
    private Vector3 m_Velocity = Vector3.zero;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //v.y = 0;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
       
        anim.SetBool("isWalking", false);
        anim.SetBool("isJumping", false);
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isWalking", true);
            Vector3 targetVelocity = new Vector2(3f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, moveSmooth);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("isWalking", true);
            Vector3 targetVelocity = new Vector2(-3f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, moveSmooth);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpTimer > 150)
            {
                anim.Play("jumpAnimation");
                //anim.SetBool("isJumping", true);
                rb.velocity = new Vector2(v.x, 10f);
                jumpTimer = 0;
            }
            
               

        }
        jumpTimer++;
        Debug.Log(jumpTimer);

    }
}
