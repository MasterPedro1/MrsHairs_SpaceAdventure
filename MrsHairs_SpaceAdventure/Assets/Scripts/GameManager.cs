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


    private void Start()
    {
        text.color = Color.green;
        text.text = "$" + coins.ToString();
    }


    public void IncreaseScore( float increaseValue)
    {
        text.color = Color.green;
        coins += increaseValue;
        text.text = "$" + coins.ToString();
    }


    public void DecreaseScore(float increaseValue)
    {
        coins -= increaseValue;
        if (coins <= 0) 
        {
            //coins = 0;
            text.color= Color.red;
            text.text = "$" + coins.ToString();
            return; 
        }
        text.color = Color.green;
        text.text = "$" + coins.ToString();
    }
}
