using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool IsPaused = false;
    public static GameManager instance;
    
    [SerializeField]
    private float Maxhealth;
    [SerializeField]
    private float Currenthealth;
    
    public GameObject Win;
    public bool IsWin = false;
    
    public GameObject Lose;
    public bool IsGameOver = false;
    
    public GameObject targetUi;
    

    public GameObject pauseMenuUi;
    
    public Transform playerTrans;
    private Vector2 startPosition;
    
    public int curCoins;
    
    public int goalCoins;

    public TextMeshProUGUI CoinPointUi;
    public TextMeshProUGUI healthUi;
    public TextMeshProUGUI DistanceText;

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
        
        Currenthealth = Maxhealth;

        startPosition = playerTrans.position;
        
        CoinPointUi.text = $"= {curCoins.ToString()}";
        
        healthUi.text = $"= {Currenthealth.ToString()}";
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

        if (IsGameOver == true || Currenthealth == 0)
        {
            Currenthealth = 0;
            GameOver();
        }

        Vector2 distance = (Vector2)playerTrans.position - startPosition;
        distance.y = 0f;

        if (distance.x < 0)
        {
            distance.x = 0;
        }

        DistanceText.text = distance.x.ToString("F0") + "m";


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
    
    public void YouWin()
    {
        if (curCoins >= goalCoins)
        {
            UISystem.instance.IsWin = true;
            UISystem.instance.Win.SetActive(true);
        }
    }
    
    public void AddCoin(int point)
    {
        curCoins += point ;
        CoinPointUi.text = $"= {curCoins.ToString()}";

    }
    
    public void TakeDamege(float t)
    {
        Currenthealth -= t;
        healthUi.text = $"= {Currenthealth.ToString()}";
    }
    
    

    
    
    
    
    
}
