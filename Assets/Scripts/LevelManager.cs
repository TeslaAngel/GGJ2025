using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "SampleScene";

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void LoadGame ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
    public void QuitGame()
    {
       Application.Quit();
    }
}