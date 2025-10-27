using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuntManager : MonoBehaviour
{
    public int runtCount;
    public TextMeshProUGUI goalText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = "Children Left: " + runtCount.ToString();

    }
}
