using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinObjectScript : ObjectsAbstract
{
    public int winObjectPower=5;
    
    void Start()
    {
        winObjectPower = winObjectPower * gameObject.GetComponentInParent<WinObjectSetScript>().winObjectPowerMultiplier;
    }

    void Update()
    {
        objectText.text = winObjectPower.ToString();
        if(winObjectPower<=0){
            this.gameObject.SetActive(false);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
    }
}
