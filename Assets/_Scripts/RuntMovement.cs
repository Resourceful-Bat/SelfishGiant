using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class RuntMovement : MonoBehaviour
{

    //[SerializeField] private Animator _animator;

    // Runt Movement Variables
    private Transform target;
    public float speedHorizontal = 1.0f;
    public float speedVertical = 1.0f;
    public float speed = 2.0f;

    //Get amount of runts left
    public RuntManager runtManager;
    public float goalCount;

    //Slowdown
    public float slowdown = 0.5f;

    //Is special runt?
    public bool isSpecial = false;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        goalCount = runtManager.runtCount;
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
            //_animator.SetBool("isRunning", true);
            RunAway();
        }
        else
        {
            //_animator.SetBool("isRunning", false);
        }

        
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
            speedHorizontal = speed;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            speedHorizontal = speed * -1.0f;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        // If player is below runt, move upward. Else, move downward.
        if (direction.y < 0)
        {
            speedVertical = speed;
        }
        else
        {
            speedVertical = speed * -1.0f;
        }

        //Change runt position
        position.x += speedHorizontal * Time.deltaTime;
        position.y += speedVertical * Time.deltaTime;
        rb.MovePosition(position);
    }
}
