using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateScipt : ObjectsAbstract
{
    public BoxCollider GateCollider;

    public int fireRateNum;

    public int bulletRangeNum;

    public int obstacleNum;

    Renderer gateRenderer;

    void Start()
    {
        bulletRangeNum = Random.Range(-10, 5);
        fireRateNum = Random.Range(-10, 5);
        
        GateCollider = gameObject.GetComponent<BoxCollider>();

        gateRenderer = GetComponent<Renderer>();

        obstacleNum = Random.Range(0, 2);
        if(obstacleNum==1){
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(this.gameObject.tag == "BulletRangeGate"){
            objectText.text = bulletRangeNum.ToString();
            if(bulletRangeNum<0){
                gateRenderer.material.color=Color.red;

            } else if(bulletRangeNum>=0){
                gateRenderer.material.color=Color.green;
            }


        }
        else if(this.gameObject.tag == "FireRateGate"){
            objectText.text = fireRateNum.ToString();
            if(fireRateNum<0){
                gateRenderer.material.color=Color.red;

            } else if(fireRateNum>=0){
                gateRenderer.material.color=Color.green;
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            if(this.gameObject.tag == "BulletRangeGate"){
                Debug.Log("Bullet Range Gate Recived Bulllet");
                bulletRangeNum = bulletRangeNum + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);


            } 
            else if(this.gameObject.tag == "FireRateGate"){
                Debug.Log("Fire Rate Gate Recived Bulllet");
                fireRateNum = fireRateNum + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
                other.gameObject.SetActive(false);

            } else if(this.gameObject.tag == "DoubleShootGate"){
                Debug.Log("Double Shoot Gate Recived Bulllet");
                other.gameObject.SetActive(false);

            } 

        }       

    }
    
}
