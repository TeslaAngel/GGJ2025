using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "Level1";

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 0;
            Application.Quit();
            //SceneManager.LoadScene("StartMenu");
        }
    }

    public void LoadGame ()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneToLoad);
	}
    public void QuitGame()
    {
       Application.Quit();
    }
}