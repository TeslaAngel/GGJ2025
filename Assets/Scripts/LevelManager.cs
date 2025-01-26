using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "SampleScene";


	public void LoadGame ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
