using UnityEngine;


public class Poi : MonoBehaviour
{
    public PoiControl poiControl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            poiControl.poiCount++;
            poiControl.winterLevel++;
            Destroy(this.GetComponent<BoxCollider2D>());
        }
    }
}
