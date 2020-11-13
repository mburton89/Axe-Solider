using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
    
public class UpgradesMenu : MonoBehaviour
{
    public TextMeshProUGUI CoinCount;

    public Button IncreaseHealthButton;
    public Button IncreaseJumpButton;
    public Button IncreaseSpeedButton;
    public Button IncreaseAxeDamageButton;

    public float amountToAddToMultiplier;

    public int costToUpgradeHealth;
    public int costToUpgradeJump;
    public int costToUpgradeSpeed;
    public int costToUpgradeDamage;

    public GameObject needMoreMoneyBroMenu;
    public AudioSource needMoreMoneySound;
    public AudioSource spentMoney;

    private void Awake()
    {
        //ONLY FOR TESTING
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("hasStaredGame") != 1)
        {
            PlayerPrefs.SetInt("hasStaredGame", 1);
            PlayerPrefs.SetFloat("healthMultiplier", 1);
            PlayerPrefs.SetFloat("speedMultiplier", 1);
            PlayerPrefs.SetFloat("jumpMultiplier", 1);
            PlayerPrefs.SetFloat("axeDamageMultiplier", 1);
        }
    }

    private void Start()
    {
        CoinCount.SetText(PlayerPrefs.GetInt("coinCount").ToString());
    }

    private void OnEnable()
    {
        IncreaseHealthButton.onClick.AddListener(IncreaseHealth);
        IncreaseJumpButton.onClick.AddListener(IncreaseJumpHeight);
        IncreaseSpeedButton.onClick.AddListener(IncreaseSpeed);
        IncreaseAxeDamageButton.onClick.AddListener(IncreaseAxeDamage);
    }

    private void OnDisable()
    {
        IncreaseHealthButton.onClick.RemoveListener(IncreaseHealth);
        IncreaseJumpButton.onClick.RemoveListener(IncreaseJumpHeight);
        IncreaseSpeedButton.onClick.RemoveListener(IncreaseSpeed);
        IncreaseAxeDamageButton.onClick.RemoveListener(IncreaseAxeDamage);
    }

    public void IncreaseHealth()
    {
        if (PlayerPrefs.GetInt("coinCount") >= costToUpgradeHealth)
        {
            PlayerPrefs.SetFloat("healthMultiplier", PlayerPrefs.GetFloat("healthMultiplier") + amountToAddToMultiplier);
            print("healthMultiplier; " + PlayerPrefs.GetFloat("healthMultiplier"));
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - costToUpgradeHealth);
            CoinCount.SetText(PlayerPrefs.GetInt("coinCount").ToString());
            SpentMoney();
        }
        else
        {
            ShowNeedMoreMoneyMenu();
        }
    }
    public void IncreaseJumpHeight()
    {
        if (PlayerPrefs.GetInt("coinCount") >= costToUpgradeJump)
        {
            PlayerPrefs.SetFloat("jumpMultiplier", PlayerPrefs.GetFloat("jumpMultiplier") + amountToAddToMultiplier);
            print("jumpMultiplier; " + PlayerPrefs.GetFloat("jumpMultiplier"));
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - costToUpgradeJump);
            CoinCount.SetText(PlayerPrefs.GetInt("coinCount").ToString());
            SpentMoney();
        }
        else
        {
            ShowNeedMoreMoneyMenu();
        }
    }
    public void IncreaseSpeed()
    {
        if (PlayerPrefs.GetInt("coinCount") >= costToUpgradeSpeed)
        {
            PlayerPrefs.SetFloat("speedMultiplier", PlayerPrefs.GetFloat("speedMultiplier") + amountToAddToMultiplier);
            print("speedMultiplier; " + PlayerPrefs.GetFloat("speedMultiplier"));
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - costToUpgradeSpeed);
            CoinCount.SetText(PlayerPrefs.GetInt("coinCount").ToString());
            SpentMoney();
        }
        else
        {
            ShowNeedMoreMoneyMenu();
        }
    }
    public void IncreaseAxeDamage()
    {
        if (PlayerPrefs.GetInt("coinCount") >= costToUpgradeDamage)
        {
            PlayerPrefs.SetFloat("axeDamageMultiplier", PlayerPrefs.GetFloat("axeDamageMultiplier") + amountToAddToMultiplier);
            print("axeDamageMultiplier; " + PlayerPrefs.GetFloat("axeDamageMultiplier"));
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - costToUpgradeDamage);
            CoinCount.SetText(PlayerPrefs.GetInt("coinCount").ToString());
            SpentMoney();
        }
        else
        {
            ShowNeedMoreMoneyMenu();
        }
    }

    void ShowNeedMoreMoneyMenu()
    {
        StartCoroutine(ShowNeedMoreMoneyMenuCo());
    }
    private IEnumerator ShowNeedMoreMoneyMenuCo()
    {
        needMoreMoneyBroMenu.SetActive(true);
        needMoreMoneySound.Play();
        yield return new WaitForSeconds(1);
        needMoreMoneyBroMenu.SetActive(false);
    }

    void SpentMoney()
    {
        spentMoney.Play();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(0);
    }
}


