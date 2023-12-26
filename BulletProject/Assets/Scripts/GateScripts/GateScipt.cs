using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateScipt : Interactable
{
    public BoxCollider GateCollider;

    public int obstacleNum;

    Renderer gateRenderer;

    void Start()
    {
        objectInt = Random.Range(-10, 5);
        
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
            objectText.text = objectInt.ToString();
            if(objectInt<0){
                gateRenderer.material.color=Color.red;

            } else if(objectInt>=0){
                gateRenderer.material.color=Color.green;
            }


        }
        else if(this.gameObject.tag == "FireRateGate"){
            objectText.text = objectInt.ToString();
            if(objectInt<0){
                gateRenderer.material.color=Color.red;

            } else if(objectInt>=0){
                gateRenderer.material.color=Color.green;
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
       base.OnTriggerEnter(other);

    }

    public override void TagAdder()
    {
        base.TagAdder();

    }
    
}
