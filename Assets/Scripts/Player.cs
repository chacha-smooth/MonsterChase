using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    [SerializeField]
    private float maxVelocity = 22f;


    private float movementX;
   
    private Rigidbody2D myBody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private SpriteRenderer sr;
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    // Start is called before the first frame update


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveKeyboard();
        AnimatePlayer();
      
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void playerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

            
    }

    void AnimatePlayer()
    {

        if (movementX > 0)
        {
            sr.flipX = false;

            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;

        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }

    void PlayerJump()
    {
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}


