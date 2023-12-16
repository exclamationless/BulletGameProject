using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleScipt : ObjectsAbstract
{
    public int obstaclePower;
    
    void Start()
    {
        gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = false;
        transform.parent.GetChild(0).gameObject.SetActive(false);

        obstaclePower = Random.Range(-10, -3);
    }

    void Update()
    {
        objectText.text = obstaclePower.ToString();
        if(obstaclePower>=0){
            gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = true;
            transform.parent.GetChild(0).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Gate Obstacle Recived Bulllet");
            obstaclePower = obstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            other.gameObject.SetActive(false);
            
        }

    }
}
