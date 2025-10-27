using UnityEngine;
using UnityEngine.InputSystem;


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
    public float speed = 5.0f;

    //Runt Manager
    public RuntManager runtManager;


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
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = transform.position;

        // Makes player move faster when Sprint button is pressed
        if (ShiftAction.IsPressed())
        {
            speed = 10.0f;
        }
        else
        {
            speed = 5.0f;
        }

        //Moves the Player
        if (LeftAction.IsPressed())
        {
            position.x -= speed * Time.deltaTime;
        }
        if (UpAction.IsPressed())
        {
            position.y += speed * Time.deltaTime;
        }
        if (RightAction.IsPressed())
        {
            position.x += speed * Time.deltaTime;
        }
        if (DownAction.IsPressed())
        {
            position.y -= speed * Time.deltaTime;
        }

        transform.position = position;

        // Capture Runt *W.I.P.
        if (SpaceAction.IsPressed())
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Runt has been collided");
        //RuntMovement runt = collision.GetComponent<RuntMovement>();
        //runt.capturedRunt();
        //rb = GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Runt"))
        {
            Destroy(collision.gameObject);
            runtManager.runtCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Runt is no longer collieded");
    }

}
