using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float coins;
    [SerializeField] TextMeshProUGUI text;
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


    public void IncreaseScore( float increaseValue)
    {
        coins += increaseValue;
        text.text = coins.ToString();
    }


    public void DecreaseScore(float increaseValue)
    {
        coins -= increaseValue;
        if (coins <= 0) 
        {
            coins = 0;
            text.text = coins.ToString();
            return; 
        }
        text.text = coins.ToString();
    }
}
