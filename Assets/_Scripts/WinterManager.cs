using UnityEngine;

public class WinterManager : MonoBehaviour
{
    // Changes Opacity. Test for winter fade in
    public SpriteRenderer spriteRenderer;

    public RuntManager runtManager;
    // Code for winter Fade in.



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color tempColor = spriteRenderer.color;
        tempColor.g = (float)runtManager.runtCount / 10+0.5f;
        spriteRenderer.color = tempColor;
    }
}
