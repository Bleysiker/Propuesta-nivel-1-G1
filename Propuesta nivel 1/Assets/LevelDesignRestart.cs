using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesignRestart : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene("LevelDesign");
        Time.timeScale = 1;
    }
}
