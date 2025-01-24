
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;

    public void SwapScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
