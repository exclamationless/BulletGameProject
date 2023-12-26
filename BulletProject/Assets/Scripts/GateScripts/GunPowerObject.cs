using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerObject : Interactable
{
    public BoxCollider gunPowerCollider;

    public int gunPowerMultiplier1 = 10;
    public int gunPowerMultiplier2 = 1;
    public int gunPowerCounter;
    
    void Start()
    {
        gunPowerCollider = gameObject.GetComponent<BoxCollider>();
        objectInt = Random.Range(-3,-16) * gunPowerMultiplier1;
        gunPowerCounter = objectInt;
    }

    void Update(){
        objectText.text = Mathf.Abs(objectInt).ToString();
        if(objectInt>=0){
            objectInt=0;
            gunPowerCollider.enabled=false;
        }
    }

    public override void OnObjectEnter(Collider other)
    {
        base.OnObjectEnter(other);
        if(other.tag == "Bullet"){
            if(Mathf.Abs(gunPowerCounter)-Mathf.Abs(objectInt) >= gunPowerMultiplier2*10 && objectInt<0){
                Singleton.instance.gunPower++;
                gunPowerMultiplier2++;
                }
        }
        
        
    }

    public override void colliderAdder()
    {
        base.colliderAdder();

    }
}
