using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Function1 : MonoBehaviour
{
    public UnityEvent events;

    public void function1()
    {
        events?.Invoke();
    }
}
