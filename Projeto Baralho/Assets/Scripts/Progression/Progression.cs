using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour

{
    static Dictionary<string, int> events = new Dictionary<string, int>() { };

    public static int GetEventCounter(string eventId)
    {
        if (events.ContainsKey(eventId))
        {
            return events[eventId];
        }
        else
        {
            return 0;
        }
    }
    public static void IncrementCounter(string eventId)
    {
        if (!events.ContainsKey(eventId))
        {
            events[eventId] = 1;
        }
        else
        {
            events[eventId] += 1;
        }
        var spriteSwitchers = FindObjectsOfType<ProgressionSpriteSwitcher>(false);
        foreach (ProgressionSpriteSwitcher spriteSwitcher in spriteSwitchers)
        {
            spriteSwitcher.UpdateSprite();
        }
    }

}