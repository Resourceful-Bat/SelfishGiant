using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PoiControl : MonoBehaviour
{
    public int poiCount = 0;
    public TextMeshProUGUI goalText;
    public int winterLevel = 0;

    void Update()
    {
        goalText.text = "Areas Left to Save: " + (3-poiCount).ToString();

        if (poiCount >= 3)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
