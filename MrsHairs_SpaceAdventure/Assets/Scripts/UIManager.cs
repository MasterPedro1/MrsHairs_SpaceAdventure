using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject playerPanel, tutorialPanel;
    [SerializeField] TextMeshProUGUI tvText, playerHelmetText;

    public static UIManager Instance;

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
        tvText.color = Color.green;
        tvText.text = "$" + GameManager.Instance.Coins.ToString();

        playerHelmetText.color = Color.green;
        playerHelmetText.text = "$" + GameManager.Instance.Coins.ToString();
    }

    public void UpdatePositiveCoinsUI()
    {
        tvText.color = Color.green;
        tvText.text = "$" + GameManager.Instance.Coins.ToString();

        playerHelmetText.color = Color.green;
        playerHelmetText.text = "$" + GameManager.Instance.Coins.ToString();
    }

    public void UpdateNegativeCoinsUI()
    {
        tvText.color = Color.red;
        tvText.text = "$" + GameManager.Instance.Coins.ToString();

        playerHelmetText.color = Color.red;
        playerHelmetText.text = "$" + GameManager.Instance.Coins.ToString();
    }

    public void ShowTutorialFinished()
    {
        tutorialPanel.SetActive(true);
    }
}
