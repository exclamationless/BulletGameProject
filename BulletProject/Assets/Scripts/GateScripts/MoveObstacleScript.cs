using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveObstacleScript : Interactable
{

    void Start()
    {
        objectInt = Random.Range(-10, -3);
    }

    void Update()
    {
        objectText.text = objectInt.ToString();
        if(objectInt>=0){
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
