using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesignRestart : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1;
    }
}
