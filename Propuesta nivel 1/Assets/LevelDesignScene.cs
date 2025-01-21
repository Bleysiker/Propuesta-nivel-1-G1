using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesignScene : MonoBehaviour
{

    public GameObject GameOver;

    public void ReStartGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("LevelDesign");
    }
}
