using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ShowGameOverScene()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }
}