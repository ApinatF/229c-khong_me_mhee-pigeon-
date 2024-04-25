using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public bool IsPaused = false;
    public static UISystem instance;
    public GameObject Win;
    public bool IsWin = false;
    

    public GameObject pauseMenuUi;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true & IsWin == false)
            {
                Resume();
            }
            else if (IsPaused == false & IsWin == false)
            {
                Pause();
            }

        }
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

     void Resume()
    {
        pauseMenuUi.SetActive(false);
        Win.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}

