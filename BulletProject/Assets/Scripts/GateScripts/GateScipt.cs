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
       base.OnTriggerEnter(other);

    }
    
}
