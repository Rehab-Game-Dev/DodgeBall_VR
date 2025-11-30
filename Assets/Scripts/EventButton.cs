using UnityEngine;
using UnityEngine.UI;

public class EventButton : MonoBehaviour
{
    public int eventIndex; // 0 = אירוע ראשון, 1 = שני, 2 = שלישי

    public void OnClick()
    {
        EventManager.instance.LoadEvent(eventIndex);
    }
}
