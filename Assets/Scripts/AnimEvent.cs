using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    Dictionary<string, Action> events = new Dictionary<string, Action>();

    public void Subscribe(string key, Action myEvent)
    {
        if (!events.ContainsKey(key))
        {
            events.Add(key, myEvent);
        }
    }

    public void ANIM_EV(string key)
    {
        if (events.ContainsKey(key))
        {
            events[key].Invoke();
        }
    }
}
