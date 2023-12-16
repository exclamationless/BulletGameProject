using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamageObjectScript : ObjectsAbstract
{
    public CapsuleCollider bulletDamageObjectCollider;

    public int bulletDamageNum;

    public bool isReverseMoving = false;
    public Vector3 targetPos;
    private float reverseRunwayspeed = 10f;

    void Start()
    {
        bulletDamageNum = Random.Range(-7, 3);

        bulletDamageObjectCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if(isReverseMoving==true){
            if(transform.position.x>-6){
                transform.Translate(Vector3.left * reverseRunwayspeed * Time.deltaTime);

            }else if(transform.position.x<=-6){
                transform.Translate(Vector3.forward * reverseRunwayspeed * Time.deltaTime);

            }
            
            

        }

        objectText.text = bulletDamageNum.ToString();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {           
            bulletDamageNum = bulletDamageNum+other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            Debug.Log("Bullet Damage Object Recived Bulllet. Bullet Damage Num = " + bulletDamageNum);
            other.gameObject.SetActive(false);
        }       
        
    }
}
