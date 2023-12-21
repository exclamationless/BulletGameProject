using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public event Action<Collider> OnEnter;
    public event Action<Collider> OnStay;
    public event Action<Collider> OnExit;

    public List<string> tagList = new List<string>();

    void Start(){
        tagList.Add("Obstacle");
        tagList.Add("MoveObstacle");
        tagList.Add("DoubleShootGate");
        tagList.Add("BulletRangeGate");
        tagList.Add("FireRateGate");
        tagList.Add("BulletDamageObject");
        tagList.Add("GunPowerObject");
        tagList.Add("WinObject");
        tagList.Add("Bullet");
        tagList.Add("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            if(this.gameObject.tag == tagList[0]){
                Debug.Log("Gate Obstacle Recived Bulllet");
                ObstacleScipt obstacleSciptRef = GetComponent<ObstacleScipt>();
                obstacleSciptRef.obstaclePower = obstacleSciptRef.obstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                
            }

            if(this.gameObject.tag == tagList[1]){
                Debug.Log("Move Obstacle Recived Bulllet");
                MoveObstacleScript moveObstacleSciptRef = GetComponent<MoveObstacleScript>();
                moveObstacleSciptRef.moveObstaclePower = moveObstacleSciptRef.moveObstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);
            }

            if(this.gameObject.tag == tagList[2]){
                Debug.Log("Double Shoot Gate Recived Bulllet");
                other.gameObject.SetActive(false);
            }
            
            if(this.gameObject.tag == tagList[3]){
                Debug.Log("Bullet Range Gate Recived Bulllet");
                GateScipt gateSciptRef = GetComponent<GateScipt>();
                gateSciptRef.bulletRangeNum = gateSciptRef.bulletRangeNum + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);
            }

            if(this.gameObject.tag == tagList[4]){
                Debug.Log("Fire Rate Gate Recived Bulllet");
                GateScipt gateSciptRef = GetComponent<GateScipt>();
                gateSciptRef.fireRateNum = gateSciptRef.fireRateNum + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);
            }

            if(this.gameObject.tag == tagList[5]){
                Debug.Log("Bullet Damage Object Recived Bulllet");
                BulletDamageObjectScript bulletDamageObjectScriptRef = GetComponent<BulletDamageObjectScript>();
                bulletDamageObjectScriptRef.bulletDamageNum = bulletDamageObjectScriptRef.bulletDamageNum+other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);
            }

            if(this.gameObject.tag == tagList[6]){
                Debug.Log("Fire Rate Gate Recived Bulllet");
                GunPowerObject gunPowerObjectRef = GetComponent<GunPowerObject>();
                gunPowerObjectRef.gunPowerNum = gunPowerObjectRef.gunPowerNum - other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                if(gunPowerObjectRef.gunPowerCounter-gunPowerObjectRef.gunPowerNum>=gunPowerObjectRef.gunPowerMultiplier2*10 && gunPowerObjectRef.gunPowerNum>0){
                Singleton.instance.gunPower++;
                gunPowerObjectRef.gunPowerMultiplier2++;
                }
                other.gameObject.SetActive(false);
            }

            if(this.gameObject.tag == tagList[7]){
                Debug.Log("Fire Rate Gate Recived Bulllet");
                WinObjectScript winObjectScriptRef = GetComponent<WinObjectScript>();
                winObjectScriptRef.winObjectPower = winObjectScriptRef.winObjectPower - other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);
            }

            Debug.Log("Event Working");
            other.gameObject.SetActive(false);
            OnEnter?.Invoke(other);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Event Working");
            other.gameObject.SetActive(false);
            OnStay?.Invoke(other);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Event Working");
            other.gameObject.SetActive(false);
            OnExit?.Invoke(other);
        }

    }
}
