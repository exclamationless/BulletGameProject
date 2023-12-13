using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinObjectScript : MonoBehaviour
{
    public int winObjectPower=5;

    public TextMeshProUGUI winObjectText;
    
    void Start()
    {
        winObjectPower = winObjectPower * gameObject.GetComponentInParent<WinObjectSetScript>().winObjectPowerMultiplier;
    }

    void Update()
    {
        winObjectText.text = winObjectPower.ToString();
        if(winObjectPower<=0){
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            winObjectPower = winObjectPower - other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            other.gameObject.SetActive(false);

        }
        
    }
}
