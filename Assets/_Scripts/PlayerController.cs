using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // Player Movement Input
    public InputAction LeftAction;
    public InputAction UpAction;
    public InputAction RightAction;
    public InputAction DownAction;

    // Sprint Button
    public InputAction ShiftAction;

    // Player Capture Button
    public InputAction SpaceAction;

    // Player Speed
    public float speed = 4.0f;
    public float stamina = 100.0f;
    public bool isExhausted = false;

    //Stamina Bar
    public Image StaminaBar;

    //Runt Manager
    public RuntManager runtManager;
    public float goalCount;

    //Snow Slowdown
    public float slowdown = 0.5f;

    //Animation
    [SerializeField] private Animator _animator;



    //Get Rigidbody
    Rigidbody2D playerRb;
    // Changes Opacity. Test for winter fade in
    //public SpriteRenderer spriteRenderer;

    // Code for winter Fade in.
    /*
    Color tempColor = spriteRenderer.color;
    tempColor.a = (float) runtManager.runtCount / 10;
    spriteRenderer.color= tempColor;
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;

        // Enables Movement Actions
        LeftAction.Enable();
        UpAction.Enable();
        RightAction.Enable();
        DownAction.Enable();
        ShiftAction.Enable();
        SpaceAction.Enable();

        goalCount = runtManager.runtCount;

        playerRb = GetComponent<Rigidbody2D>();


        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float slowdown_Value = slowdown * (goalCount - runtManager.runtCount);
        Vector2 position = transform.position;

        //Sets the slowdown weight
        //slowdown *= (goalCount - runtManager.runtCount);
        

        // Makes player move faster when Sprint button is pressed
        if (ShiftAction.IsPressed() && stamina > 1 && isExhausted != true)
        {
            speed = 6.5f;
            stamina -= 1.0f;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            speed = 4.0f;
            if (stamina < 100)
            {
                stamina += 0.5f;
            }
            _animator.SetBool("isRunning", false);
        }

        //Checks for exhaustion
        if (stamina <= 1)
        {
            speed = 4.0f;
            isExhausted = true;
            
            StaminaBar.color = new Color(137, 105, 76);

        }
        if(isExhausted == true)
        {
            _animator.SetBool("isRunning", true);
            speed = 4.0f;
            if(stamina > 100)
            {
                isExhausted = false;
                StaminaBar.color = new Color(245, 229, 215);
            }
            if (stamina < 100)
            {
                stamina += 0.05f;
            }
        }

        //Moves the Player
        if (LeftAction.IsPressed())
        {
            position.x -= (speed - slowdown_Value) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().flipX = true;
            _animator.SetBool("isWalking", true);
        }
        if (UpAction.IsPressed())
        {
            position.y += (speed - slowdown_Value) * Time.deltaTime;
            _animator.SetBool("isWalking", true);

        }
        if (RightAction.IsPressed())
        {
            position.x += (speed - slowdown_Value) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().flipX = false;
            _animator.SetBool("isWalking", true);
        }
        if (DownAction.IsPressed())
        {
            position.y -= (speed - slowdown_Value) * Time.deltaTime;
            _animator.SetBool("isWalking", true);
        }

        if (!(LeftAction.IsPressed() || DownAction.IsPressed() || UpAction.IsPressed() || RightAction.IsPressed()))
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isRunning", false);
        }

        //transform.position = position;
        playerRb.MovePosition(position);
        StaminaBar.fillAmount = stamina / 100;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Runt"))
        {
            Destroy(collision.gameObject);
            runtManager.runtCount--;

        }
    }

}
