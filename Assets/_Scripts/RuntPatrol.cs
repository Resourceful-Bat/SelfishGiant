using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class RuntPatrol : MonoBehaviour
{
    public Transform patrolParent;
    public float speed = 15.0f;
    public float slowdown=1.5f;
    public float detectionRange = 3.0f;
    

    //Get amount of runts left
    public RuntManager runtManager;
    public float goalCount;

    //Get list of points for patrol route
    private Transform[] Points;
    private int index=0;

    //Player Position
    private Transform target;

    //Animation Direction
    [SerializeField] private Animator _animator;


    void Start()
    {
        Points=new Transform[patrolParent.childCount];

        for(int i = 0; i < patrolParent.childCount; i++)
        {
            Points[i]=patrolParent.GetChild(i);

        }

        transform.position = Points[index].transform.position;
        goalCount = runtManager.runtCount;

        _animator.SetBool("isRunning", true);

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Move Runt to next point in path
        if (index <= Points.Length - 1)
        {
            //If Player is near, run.
            Vector2 position = transform.position;
            float distance = Vector2.Distance(target.position, position);

            if (distance < detectionRange)
            {
                MoveToPoint();
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }

            if (transform.position == Points[index].transform.position)
            {
                index++;
            }

            if (index >= Points.Length)
            {
                index = 0;
            }

            //Changes sprite direction
            if (index >= Points.Length / 2)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void MoveToPoint()
    {
        Transform target = Points[index];
        float slowdown_Value = slowdown * (goalCount - runtManager.runtCount);

        transform.position = Vector2.MoveTowards(transform.position, target.position, (speed-slowdown_Value)*Time.deltaTime);

    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        for(int i = 0; i<Points.Length-1; i++)
        {
            Gizmos.DrawLine(Points[i].transform.position, Points[i+1].transform.position);
        }
        
    }
    */
}
