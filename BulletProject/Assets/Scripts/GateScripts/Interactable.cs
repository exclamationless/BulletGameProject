using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
  public TextMeshProUGUI objectText;

  public int objectInt;

  public List<string> tagList = new List<string>();

  public void Start(){

    var triggerListenerRef = new TriggerListener();

    triggerListenerRef.OnEnter += OnTriggerEnter;

    triggerListenerRef.OnStay += OnTriggerStay;

    triggerListenerRef.OnExit += OnTriggerExit;
    
  }

  public virtual void TagAdder()
    {
        tagList.Add(this.gameObject.tag);
    }
  
  public virtual void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Bullet")
        {
          Debug.Log("Object Recived Bulllet");
          objectInt = objectInt + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
          Debug.Log("Event Working");
          other.gameObject.SetActive(false);
        
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
