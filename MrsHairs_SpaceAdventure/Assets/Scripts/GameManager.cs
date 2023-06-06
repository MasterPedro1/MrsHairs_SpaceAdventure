using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float coins;
    
    public float Coins { get { return coins; } set { coins = value; } }

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        Time.timeScale = 1;
       
    }


    public void IncreaseScore( float increaseValue)
    {
        coins += increaseValue;
        UIManager.Instance.UpdatePositiveCoinsUI();
    }


    public void DecreaseScore(float increaseValue)
    {
        coins -= increaseValue;
        if (coins <= 0) 
        {
            //coins = 0;
            UIManager.Instance.UpdateNegativeCoinsUI();
            return; 
        }
        UIManager.Instance.UpdatePositiveCoinsUI();
    }

    public void StopTutorial()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowTutorialFinished();
    }
}
