using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
  public TextMeshProUGUI objectText;

  public int objectInt;

  private bool isTagAdded = true;

  [SerializeField]
  protected TriggerListener triggerListenerRef;

  private void OnEnable(){

    triggerListenerRef.OnEnter += OnObjectEnter;

    triggerListenerRef.OnStay += OnObjectStay;

    triggerListenerRef.OnExit += OnObjectExit;

    colliderAdder();
    
  }

  private void OnDisable(){

    triggerListenerRef.OnEnter -= OnObjectEnter;

    triggerListenerRef.OnStay -= OnObjectStay;

    triggerListenerRef.OnExit -= OnObjectExit;
    
  }

  public virtual void colliderAdder()
  {
    triggerListenerRef.colliderList.Add(GetComponent<Collider>());
  }
  
  public virtual void OnObjectEnter(Collider other)
    {
      if(other.TryGetComponent(out BulletScript bullet))
        {
          Debug.Log("Object Recived Bulllet");
          objectInt = objectInt + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
          other.gameObject.SetActive(false);

           if(isTagAdded){
            triggerListenerRef.tagList.Add(other.tag);
            isTagAdded=false;
          }
        
        }

    }

  public virtual void OnObjectStay(Collider other)
    {
      if(other.TryGetComponent(out BulletScript bullet))
        {
          Debug.Log("Object Recived Bullet OnTriggerStay");
          //other.gameObject.SetActive(false);
        
        }

    }

  public virtual void OnObjectExit(Collider other)
    {
      if(other.TryGetComponent(out BulletScript bullet))
        {
          Debug.Log("Object Recived Bullet OnTriggerExit");
          //other.gameObject.SetActive(false);
        
        }

    }
}
