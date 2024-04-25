using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public static SceneSystem instance;
    [Header("Sting = sceneName ")]
    public bool isGameOver;
    //public object gameOverUI;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ToSeene(string sceneName)
    {
        name = sceneName;
        SceneManager.LoadScene(name);
    }
    public void TurnMenuGame()
    {

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   /* public void Rusume()
    {
        if (PauseMenu.instance != null)
        {
            PauseMenu.instance.Resume();
        }
    }*/
}
