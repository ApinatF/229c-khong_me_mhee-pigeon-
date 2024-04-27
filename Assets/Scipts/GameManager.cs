using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsPaused = false;
    public static GameManager instance;
    
    public GameObject Win;
    public bool IsWin = false;
    
    public GameObject Lose;
    public bool IsGameOver = false;

    [SerializeField]
    private GameObject targetUi;
    

    public GameObject pauseMenuUi;
    
    public int curCoins;
    
    public int goalCoins;

    public TextMeshProUGUI CoinPointUi;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        Cursor.visible = false;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        
        CoinPointUi.text = $"Coin = {curCoins.ToString()} / {goalCoins.ToString()}";
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
        
        if (IsWin == true)
        {
            Winner();
        }

        if (IsGameOver == true)
        {
            GameOver();
        }
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.visible = true;
        targetUi.SetActive(false);
    }

    void Resume()
    {
        
        pauseMenuUi.SetActive(false);
        Win.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
        targetUi.SetActive(true);
    }

    public void Winner()
    {
        Win.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        targetUi.SetActive(false);
    }
    
    public void GameOver()
    {
        Lose.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        targetUi.SetActive(false);
    }
    
    public void AddCoin(int point)
    {
        curCoins += point ;
        CoinPointUi.text = $"Coin = {curCoins.ToString()} / {goalCoins.ToString()}";

    }
    
    public void YouWin()
    {
        if (curCoins >= goalCoins)
        {
            UISystem.instance.IsWin = true;
            UISystem.instance.Win.SetActive(true);
            
        }

    }
}
