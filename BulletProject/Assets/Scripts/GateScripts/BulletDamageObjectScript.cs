using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamageObjectScript : Interactable
{
    public CapsuleCollider bulletDamageObjectCollider;

    public int bulletDamageNum;

    public bool isReverseMoving = false;
    public Vector3 targetPos;
    private float reverseRunwayspeed = 10f;

    void Start()
    {
        objectInt = Random.Range(-7, 3);

        bulletDamageObjectCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        bulletDamageNum = objectInt;
        if(isReverseMoving==true){
            if(transform.position.x>-6){
                transform.Translate(Vector3.left * reverseRunwayspeed * Time.deltaTime);

            }else if(transform.position.x<=-6){
                transform.Translate(Vector3.forward * reverseRunwayspeed * Time.deltaTime);

            }
            
            

        }

        objectText.text = objectInt.ToString();
    }

    public override void OnObjectEnter(Collider other)
    {
        base.OnObjectEnter(other);
        if(other.TryGetComponent(out BulletScript bullet))
        {
          objectInt = objectInt + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
          other.gameObject.SetActive(false);

           if(isTagAdded){
            triggerListenerRef.tagList.Add(other.tag);
            isTagAdded=false;
          }
        
        }
    }

    public override void colliderAdder()
    {
        base.colliderAdder();

    }
}
