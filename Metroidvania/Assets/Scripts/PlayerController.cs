using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint; //the empty checker
    private bool isOnGround; 
    public LayerMask whatIsGround; //searches for a layer

    public Animator anim;

    public BulletControler shotToFire;
    public Transform shotPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move side ways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal")* moveSpeed , theRB.velocity.y);


        //handle direction change
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }



        //checking if on ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);


        //jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x,0f);
        }









        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x) );
    }
}
