using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageColllectorScript : MonoBehaviour
{
    BoxCollider garbageColllectorCollider; 

    void Start()
    {
        garbageColllectorCollider = gameObject.GetComponent<BoxCollider>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
