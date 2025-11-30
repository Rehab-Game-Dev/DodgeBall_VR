using UnityEngine;
using TMPro;

public class BetManager : MonoBehaviour
{
    public GameObject betPanel;
    public TMP_InputField amountInput;
    public int selectedEvent;

    // 🆕 חדש — שומר האם בחרנו A או B
    // -1 = לא נבחר, 0 = A, 1 = B
    public int chosenOption = -1;

    public void SetSelectedEvent(int index)
    {
        selectedEvent = index;
        betPanel.SetActive(true);
    }

    // 🆕 חדש — בחירת A
    public void ChooseA()
    {
        chosenOption = 0;
        Debug.Log("Chose A");
    }

    // 🆕 חדש — בחירת B
    public void ChooseB()
    {
        chosenOption = 1;
        Debug.Log("Chose B");
    }

    public void ConfirmBet()
    {
        // 🆕 בדיקה: האם בחרנו A או B?
        if (chosenOption == -1)
        {
            Debug.Log("❌ You must choose A or B before confirming!");
            return;
        }

        // לא קלטת מספר
        if (string.IsNullOrEmpty(amountInput.text))
            return;

        int amount;
        if (!int.TryParse(amountInput.text, out amount))
            return;

        // כאן יורד כסף
        bool success = GameManager.instance.SpendMoney(amount);

        if (!success)
        {
            Debug.Log("❌ Not enough money!");
            return;
        }

        // מוסיף Heat לפי מספר האירוע
        GameManager.instance.AddHeat(selectedEvent + 1);

        // סוגר את הפאנל
        betPanel.SetActive(false);

        // מאפס בחירה לשלב הבא
        chosenOption = -1;
    }
}
