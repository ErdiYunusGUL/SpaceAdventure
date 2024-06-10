using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    public float speed;
    public float acceleration;
    public float deceleration;
    public float jumpPower;

    public int jumpLimit = 3;

    int jumpCount;

    Joystick joystick;

    JoystickButton joystickButton;

    bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        Control();
#else
      JoystickControl();
#endif

        

    }


    void Control()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            JumpStart();
        }

        if (Input.GetKeyUp("space"))
        {
            JumpEnd();
        }
    }

    void JoystickControl()
    {
        float moveInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (joystickButton.buttonPressed == true && jumping == false)
        {
            jumping = true;
            JumpStart();
        }

        if (joystickButton.buttonPressed == false && jumping == true)
        {
            jumping = false;
            JumpEnd();
        }
    }

    void JumpStart()
    {
        if (jumpCount < jumpLimit)
        {
            FindObjectOfType<AudioControl>().JumpSound();
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
        }
        
    }

    void JumpEnd()
    {
        animator.SetBool("Jump", false);
        jumpCount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
    }

    public void JumpReset()
    {
        jumpCount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            FindObjectOfType<GameManager>().GameFinish();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }
}
