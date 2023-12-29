using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
  public TextMeshProUGUI objectText;

  public int objectInt;

  protected bool isTagAdded = true;

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
    Debug.Log("OnObjectEnter Working");

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
