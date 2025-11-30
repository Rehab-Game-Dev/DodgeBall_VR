using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Stats")]
    public int money = 100;
    public int heat = 0;

    [Header("UI References")]
    public TMP_Text moneyText;
    public Slider heatSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public void AddHeat(int amount)
    {
        heat += amount;
        heatSlider.value = heat;
    }

    private void UpdateUI()
    {
        moneyText.text = "Money: " + money;
        heatSlider.value = heat;
    }
}
