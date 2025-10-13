using UnityEngine;

public class Runts : MonoBehaviour
{
    public float speed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 position = transform.position;
        position.x += speed;
        transform.position = position;
        
    }
}
