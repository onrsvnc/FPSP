using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        Debug.Log("reloaded");
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.buildIndex);
        Time.timeScale = 1;
        FindObjectOfType<SFPSC_FPSCamera>().enabled = true;
    }

    public void QuitGame()
    {
        Debug.Log("quitted");
        Time.timeScale = 1;
        FindObjectOfType<SFPSC_FPSCamera>().enabled = true;
        Application.Quit();
    }
}
