using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinObjectScript : Interactable
{
    public int winObjectPower;

    
    void Start()
    {
        objectInt = -5;
        objectInt = objectInt * gameObject.GetComponentInParent<WinObjectSetScript>().winObjectPowerMultiplier;
    }

    void Update()
    {
        winObjectPower = Mathf.Abs(objectInt);
        objectText.text = Mathf.Abs(objectInt).ToString();
        if(objectInt>=0){
            this.gameObject.SetActive(false);
        }
    }

    public override void OnObjectEnter(Collider other)
    {
        base.OnObjectEnter(other);
        
    }

    public override void colliderAdder()
    {
        base.colliderAdder();

    }
}
