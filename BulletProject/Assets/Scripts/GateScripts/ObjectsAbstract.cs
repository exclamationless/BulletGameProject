using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ObjectsAbstract : MonoBehaviour
{
  public TextMeshProUGUI objectText;
  
  public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Object Recived Bulllet");
            other.gameObject.SetActive(false);
        }

    }
}
