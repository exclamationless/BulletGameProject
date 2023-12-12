using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    CapsuleCollider playerCollider; 

    public GunScript gunScriptRef;

    public GameObject winCanvas;

    public int backSpeed = 2;
    public bool goingBack = false;
    
    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        Singleton.instance.fireRate = 1f;
        Singleton.instance.bulletRange = 1f;
    }

    void Update(){
        if(goingBack == true){
            transform.Translate(Vector3.back * backSpeed * Time.deltaTime);
            Invoke("GoForward", 1.0f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DoubleShootGate")
        {
            Debug.Log("Double Shoot Trigger");
            gunScriptRef.doubleShoot=true;

        }

        else if(other.tag == "FireRateGate")
        {
            if(other.gameObject!=null){
                float tempFireRateNum = other.gameObject.GetComponent<GateScipt>().fireRateNum;
                Singleton.instance.fireRate = Singleton.instance.fireRate - (tempFireRateNum/100);
                Debug.Log("FireRate = " + tempFireRateNum/100);

            }
            
        }

        else if(other.tag == "BulletRangeGate")
        {
            if(other.gameObject!=null){
                float tempBulletRangeNum = other.gameObject.GetComponent<GateScipt>().bulletRangeNum;
                Singleton.instance.bulletRange = Singleton.instance.bulletRange + (tempBulletRangeNum/100);
                Debug.Log("BulletRange = " + tempBulletRangeNum);

            }
            
        }

        else if(other.tag == "BulletDamageObject")
        {
            /*if(other.gameObject!=null){
                gunScriptRef.bulletDamage[0] = other.gameObject.GetComponent<BulletDamageObjectScript>().bulletDamageNum;
                Debug.Log("Bullet Damage = " + gunScriptRef.bulletDamage[0]);

            }*/
            if(other.gameObject!=null){
                other.gameObject.GetComponent<RunwayMover>().RunwaySpeed = 0;
                other.gameObject.GetComponent<BulletDamageObjectScript>().isReverseMoving = true;

            }
            
        }

        else if(other.tag == "CutsceneGate")
        {
            if(other.gameObject!=null){
                if(other.gameObject.GetComponent<CutsceneScript>().currentBulletNum==1){
                    gunScriptRef.bulletDamage[0] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[0];
                } 
                
                else if(other.gameObject.GetComponent<CutsceneScript>().currentBulletNum==2){
                    gunScriptRef.bulletDamage[0] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[0];
                    gunScriptRef.bulletDamage[1] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[1];
                }
                
                else if(other.gameObject.GetComponent<CutsceneScript>().currentBulletNum==3){
                    gunScriptRef.bulletDamage[0] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[0];
                    gunScriptRef.bulletDamage[1] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[1];
                    gunScriptRef.bulletDamage[2] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[2];
                } 
                
                else if(other.gameObject.GetComponent<CutsceneScript>().currentBulletNum>=4){
                    gunScriptRef.bulletDamage[0] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[0];
                    gunScriptRef.bulletDamage[1] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[1];
                    gunScriptRef.bulletDamage[2] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[2];
                    gunScriptRef.bulletDamage[3] = other.gameObject.GetComponent<CutsceneScript>().BulletHolder[3];
                }
                Debug.Log("Cutscene gate reached = ");
                goingBack = true;

                

            }
            
        }

        else if(other.tag == "Obstacle")
        {
            goingBack = true;

        }

        else if(other.tag == "WinObject")
        {
            Singleton.instance.playerMoney = Singleton.instance.playerMoney + other.gameObject.GetComponent<WinObjectScript>().winObjectPower;
            winCanvas.SetActive(true);
            playerCollider.enabled =false;

        }
        
    }

    void GoForward(){
        goingBack = false;
    }
}
