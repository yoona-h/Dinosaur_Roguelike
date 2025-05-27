using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Function : MonoBehaviour
{
    public UnityEvent events;

    public void function()
    {
        events?.Invoke();
    }
}
