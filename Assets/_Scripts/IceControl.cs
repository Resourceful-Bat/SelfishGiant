using UnityEngine;

public class IceControl : MonoBehaviour
{

    public PoiControl poiControl;
    Rigidbody2D rb;

    //Level of Winter
    public int frostTrigger;

    //Get Ice GameObject
    GameObject iceBlock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && poiControl.winterLevel >= frostTrigger)
        {
            Debug.Log("Ice Spawned");
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        
        
    }
}
