using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private BoxCollider2D coll2d;

    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private bool crouch;
    [SerializeField] private Vector2 standingSize;
    [SerializeField] private Vector2 crouchingSize;


    // Update is called once per frame

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        coll2d = gameObject.GetComponent<BoxCollider2D>();
        standingSize = coll2d.size;
    }
    void Update()
    {
        //getting input value in a variable
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        playerAnimation(horizontal, vertical, crouch);
        playerMovement(horizontal, vertical, crouch);
    }

    void playerAnimation(float horizontal, float vertical, bool crouch)
    {
        #region flip left right animation

        //setting input value to speed variable
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        #endregion

        #region jump animation
        if (vertical > 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
        #endregion

        #region crouch animation
        if (crouch)
        {
            animator.SetBool("crouch", true);
        }
        else
        {
            animator.SetBool("crouch", false);
        }
        #endregion
    }

    void playerMovement(float horizontal, float vertical, bool crouch)
    {
        #region left right movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        #endregion

        #region jump movment
        if (vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
        #endregion

        #region crouch
        if (crouch)
        {
            coll2d.size = crouchingSize;

        }
        else
        {
            coll2d.size = standingSize;
        }
        #endregion
    }

}
