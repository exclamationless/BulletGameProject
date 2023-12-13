using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShootGate : MonoBehaviour
{
    private GameObject tempPlayerRef;

    BoxCollider gateCollider;
    void Start()
    {
        gateCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<GunScript>().doubleShoot=true;

        }
        if(other.tag == "Bullet")
        {
            other.gameObject.SetActive(false);

        }
           
        
    }
}
