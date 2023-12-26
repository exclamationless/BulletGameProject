using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleScipt : Interactable
{
    void Start()
    {
        gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = false;
        transform.parent.GetChild(0).gameObject.SetActive(false);

        objectInt = Random.Range(-10, -3);
    }

    void Update()
    {
        objectText.text = objectInt.ToString();
        if(objectInt>=0){
            gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = true;
            transform.parent.GetChild(0).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
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
