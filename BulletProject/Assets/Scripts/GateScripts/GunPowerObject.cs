using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerObject : ObjectsAbstract
{
    public BoxCollider gunPowerCollider;

    private int gunPowerMultiplier1 = 10;
    private int gunPowerMultiplier2 = 1;
    public int gunPowerNum;
    private int gunPowerCounter;
    
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
        if(other.tag == "Bullet")
        {
            gunPowerNum = gunPowerNum - other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            if(gunPowerCounter-gunPowerNum>=gunPowerMultiplier2*10 && gunPowerNum>0){
                Singleton.instance.gunPower++;
                gunPowerMultiplier2++;

            }
            other.gameObject.SetActive(false);

        }
    }
}
