using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletSpeed =10;
    public int tempBulletDamage;
    
    
    void Start()
    {
        if(gameObject.transform.parent != null){
            tempBulletDamage = this.gameObject.GetComponentInParent<GunScript>().bulletDamage[0];

        }
        this.gameObject.transform.parent = null;
        Invoke("destroy", Singleton.instance.bulletRange);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position+ new Vector3(0f, 0f, 5f), bulletSpeed * Time.deltaTime);
    }

    void destroy(){
        Debug.Log(tempBulletDamage);
        Destroy(gameObject);
    }
}
