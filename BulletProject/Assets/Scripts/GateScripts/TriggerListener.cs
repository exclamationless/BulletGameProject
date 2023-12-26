using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerListener : MonoBehaviour
{
    public event Action<Collider> OnEnter;

    public event Action<Collider> OnStay;

    public event Action<Collider> OnExit;

    [SerializeField]
    public List<string> tagList;
    public List<Collider> colliderList;

    public void OnTriggerEnter(Collider other)
    {
        if(tagList.Count > 0 && !tagList.Contains(other.tag))
        {
            foreach(var col in colliderList)
            {
                Physics.IgnoreCollision(col, other);
            }
           return;
        }
        Debug.Log("Event Working Enter");
        OnEnter?.Invoke(other);

    }

    public void OnTriggerStay(Collider other)
    {
        if(tagList.Count > 0 && !tagList.Contains(other.tag))
        {
            foreach(var col in colliderList)
            {
                Physics.IgnoreCollision(col, other);

            }
           return;
        }
        Debug.Log("Event Working Stay");
        OnStay?.Invoke(other);

    }

    public void OnTriggerExit(Collider other)
    {
        if(tagList.Count > 0 && !tagList.Contains(other.tag))
        {
            foreach(var col in colliderList)
            {
                Physics.IgnoreCollision(col, other);

            }
           return;
        }
        Debug.Log("Event Working Exit");
        OnExit?.Invoke(other);

    }
}
