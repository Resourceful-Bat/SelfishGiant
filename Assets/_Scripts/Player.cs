using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    public float speed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Running");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Player Controls
        // UP
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y + speed);

            gameObject.transform.position = pos;
        }
        
        //DOWN
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y - speed);

            gameObject.transform.position = pos;
        }

        //LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x - speed,
                gameObject.transform.position.y);

            gameObject.transform.position = pos;
        }

        //RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x + speed,
                gameObject.transform.position.y);

            gameObject.transform.position = pos;
        }
        */

        // Right Movement
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Vector2 position = transform.position;
            position.x += speed;
            transform.position = position;
        }

        
        
    }
}
