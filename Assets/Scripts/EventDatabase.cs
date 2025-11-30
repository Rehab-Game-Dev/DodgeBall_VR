using UnityEngine;

[CreateAssetMenu(fileName = "EventDatabase", menuName = "Events/Event Database")]
public class EventDatabase : ScriptableObject
{
    public EventData[] events;
}
