using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamageObjectScript : MonoBehaviour
{
    public CapsuleCollider bulletDamageObjectCollider;

    public int bulletDamageNum;

    public bool isReverseMoving = false;
    public Vector3 targetPos;
    private float reverseRunwayspeed = 10f;

    public TextMeshProUGUI bulletDamageText;

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

        bulletDamageText.text = bulletDamageNum.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {           
            bulletDamageNum = bulletDamageNum+other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            Debug.Log("Bullet Damage Num = " + bulletDamageNum);
            other.gameObject.SetActive(false);


        }
           
        
        
    }
}
