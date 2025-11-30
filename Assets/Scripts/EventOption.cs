using System;
using UnityEngine;

[Serializable]
public class EventOption
{
    public string fighterName;     // שם המתחרה / אפשרות A או B
    public float ratio;            // יחס זכייה
    public int chanceToWin;        // סיכוי לזכות
    public int heatGain;           // כמה HEAT מתווסף
}
