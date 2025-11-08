using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    public bool activated;
    public float timeLeft;
    public TextMeshProUGUI timeText;

    //Minutes and Seconds
    private int minutes;
    private int seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get values of minutes and seconds left on timer
        minutes = (int)(timeLeft / 60);
        seconds = (int)(timeLeft % 60);

        if (!(timeLeft <= 0) && activated == true)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = string.Format("Eternal Winter Approaches...\n{0:00}:{1:00}",minutes,seconds);
        }
        else
        {
            timeText.text = "Eternal Winter Approaches...\n00:00";
            activated = false;
            SceneManager.LoadScene("Level2");
        }
    }

}
