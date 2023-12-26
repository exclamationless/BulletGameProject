using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public event Action<Collider> OnEnter;
    public event Action<Collider> OnStay;
    public event Action<Collider> OnExit;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Event Working");
            OnEnter?.Invoke(other);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Event Working");
            OnStay?.Invoke(other);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Event Working");
            OnExit?.Invoke(other);
        }

    }
}
