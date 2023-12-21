using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerObject : ObjectsAbstract
{
    public BoxCollider gunPowerCollider;

    public int gunPowerMultiplier1 = 10;
    public int gunPowerMultiplier2 = 1;
    public int gunPowerNum;
    public int gunPowerCounter;
    
    void Start()
    {
        gunPowerCollider = gameObject.GetComponent<BoxCollider>();
        gunPowerNum = Random.Range(3,16)*gunPowerMultiplier1;
        gunPowerCounter = gunPowerNum;
    }

    void Update(){
        objectText.text = gunPowerNum.ToString();
        if(gunPowerNum<=0){
            gunPowerNum=0;
            gunPowerCollider.enabled=false;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
