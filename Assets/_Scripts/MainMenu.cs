using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Val Index of Scene to Move To
    public int sceneBuildIndex;
    public void Play()
    {

        SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Quit()
    {
        //Quits the game in both the build version and the Editor version
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
    }
}
