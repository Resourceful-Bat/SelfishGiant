using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class RuntMovement : MonoBehaviour
{


    // Runt Movement Variables
    public Transform target;
    public float speedHorizontal = 1.0f;
    public float speedVertical = 1.0f;
    private Rigidbody2D rb;

    // Runt captured variable
    public bool isCaptured = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float distance = Vector2.Distance(target.position, position);

        string horizontalValue = direction.ToString();
        //If player is within a certain distance of runt, run away
        if (distance < 5)
        {
            RunAway();
        }
        //RunAway();
    }

    void RunAway()
    {
        Vector2 position = transform.position;

        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        // Move away from player
        // If player is behind runt, move forward. Else, move backward.
        if (direction.x < 0)
        {
            speedHorizontal = 1.0f;
        }
        else
        {
            speedHorizontal = -1.0f;
        }
        // If player is below runt, move upward. Else, move downward.
        if (direction.y < 0)
        {
            speedVertical = 1.0f;
        }
        else
        {
            speedVertical = -1.0f;
        }

        //If captured, set Runt position = Player position
        if (isCaptured == true)
        {
            capturedRunt();
        }


        //Change runt position
        position.x += speedHorizontal * Time.deltaTime;
        position.y += speedVertical * Time.deltaTime;
        transform.position = position;
    }

    public void capturedRunt()
    {
        isCaptured = true;
        speedVertical = 0.0f;
        speedHorizontal = 0.0f;
    }

    public void freedRunt()
    {
        isCaptured = false;
    }
}
