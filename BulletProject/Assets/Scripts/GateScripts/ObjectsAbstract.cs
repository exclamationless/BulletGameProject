using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ObjectsAbstract : MonoBehaviour
{
  public TextMeshProUGUI objectText;

  public void Start(){
    var triggerListenerRef = new TriggerListener();

    triggerListenerRef.OnEnter += OnTriggerEnter;

    triggerListenerRef.OnStay += OnTriggerStay;

    triggerListenerRef.OnExit += OnTriggerExit;
    
  }
  
  public virtual void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Bullet")
        {
           
          Debug.Log("Object Recived Bullet OnTriggerEnter");
          //other.gameObject.SetActive(false);
        
        }

    }

  public virtual void OnTriggerStay(Collider other)
    {
      if(other.tag == "Bullet")
        {
          Debug.Log("Object Recived Bullet OnTriggerStay");
          //other.gameObject.SetActive(false);
        
        }

    }

  public virtual void OnTriggerExit(Collider other)
    {
      if(other.tag == "Bullet")
        {
          Debug.Log("Object Recived Bullet OnTriggerExit");
          //other.gameObject.SetActive(false);
        
        }

    }
}