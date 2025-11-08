using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class RuntManager : MonoBehaviour
{
    public int runtCount;
    public int poiCount;
    public int winterLevel;
    public TextMeshProUGUI goalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winterLevel = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = "Children Left: " + runtCount.ToString();
        if(runtCount <= 1)
        {
            winterLevel = 3;
        }
        else if (runtCount <= 4)
        {
            winterLevel = 2;
        }
        else if (runtCount <= 7)
        {
            winterLevel = 1;
        }
        else
        {
            winterLevel = 0;
        }

        if(runtCount <= 0 && SceneManager.GetActiveScene().name == "Level1")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        
    }

}
