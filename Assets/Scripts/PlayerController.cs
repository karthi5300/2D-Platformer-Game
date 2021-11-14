using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private bool crouch;

    public GameObject[] hearts;
    private int life;
    private bool isGrounded;

    public GameObject playerDeathText;
    public ScoreController scoreController;
    public GameOverController gameOverController;

    public AudioClip playerDeadSound;
    public AudioClip playerJumpStartSound;
    public AudioClip playerJumpEndSound;
    public AudioClip playerWalkSound;
    public AudioClip playerHurtSound;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = true;
        life = hearts.Length;
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
        if (vertical > 0 && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            isGrounded = false;
        }
        #endregion
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            SoundManager.Instance.Play(playerDeadSound);
            Destroy(hearts[0].gameObject);
            animator.SetBool("isDead", true);
            gameOverController.PlayerDied();
            Debug.Log("Player Died...Game Over");
            this.enabled = false;   //disables the gameobject which uses this script
            Destroy(gameObject);
        }
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        if (life > 2)
        {
            SoundManager.Instance.Play(playerHurtSound);
            Destroy(hearts[2].gameObject);
            animator.SetBool("isHurt", true);
            this.CallWithDelay(ResetPlayerHurtAnimation, 0.5f);
        }
        else if (life > 1)
        {
            SoundManager.Instance.Play(playerHurtSound);
            Destroy(hearts[1].gameObject);
            animator.SetBool("isHurt", true);
            this.CallWithDelay(ResetPlayerHurtAnimation, 0.5f);
        }
        else if (life > 0)
        {
            SoundManager.Instance.Play(playerHurtSound);
            SoundManager.Instance.Play(playerDeadSound);
            Destroy(hearts[0].gameObject);
            animator.SetBool("isDead", true);
            gameOverController.PlayerDied();
            Debug.Log("Player Died...Game Over");
            this.enabled = false;   //disables the gameobject which uses this script
        }
        life--;
    }

    public void ResetPlayerHurtAnimation()
    {
        animator.SetBool("isHurt", false);
    }

    public void JumpStartSound()
    {
        SoundManager.Instance.Play(playerJumpStartSound);
    }
    public void JumpEndSound()
    {
        SoundManager.Instance.Play(playerJumpEndSound);
    }
}