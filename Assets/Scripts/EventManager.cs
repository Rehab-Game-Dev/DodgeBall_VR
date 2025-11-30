using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    public EventDatabase database;   // מושך את כל האירועים מה-asset
    public TMP_Text titleText;       // טקסט שם האירוע
    public TMP_Text optionAText;     // טקסט של A
    public TMP_Text optionBText;     // טקסט של B

    private int currentEventIndex = -1;
    public static EventManager instance;

    private void Awake()
    {
        instance = this;
    }

    // קוראים לזה כשנלחץ כפתור Event 1/2/3
    public void LoadEvent(int index)
    {
        if (index < 0 || index >= database.events.Length)
        {
            Debug.LogError("Event index out of range!");
            return;
        }

        currentEventIndex = index;

        EventData e = database.events[index];

        // מעדכן UI
        titleText.text = e.title;

        optionAText.text =
            $"{e.optionA.fighterName}\n" +
            $"Ratio: {e.optionA.ratio}\n" +
            $"Chance: {e.optionA.chanceToWin}%\n" +
            $"Heat: {e.optionA.heatGain}";

        optionBText.text =
            $"{e.optionB.fighterName}\n" +
            $"Ratio: {e.optionB.ratio}\n" +
            $"Chance: {e.optionB.chanceToWin}%\n" +
            $"Heat: {e.optionB.heatGain}";
    }

    // קוראים לזה בזמן לחיצה על A/B
    public void ChooseOption(bool chooseA)
    {
        if (currentEventIndex < 0)
        {
            Debug.Log("No event chosen.");
            return;
        }

        EventData e = database.events[currentEventIndex];

        EventOption chosen = chooseA ? e.optionA : e.optionB;

        bool win = Random.Range(0, 100) < chosen.chanceToWin;

        Debug.Log($"Chose {(chooseA ? "A" : "B")} → {(win ? "WIN" : "LOSE")}");

        // כאן נוסיף מאוחר יותר כסף / חום / הפסד משחק
    }
}
