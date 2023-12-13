using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int horizontalSpeed = 10;
    public float leftBoundary = -4.5f;
    public float rightBoundary = 4.5f;

    public GameObject bullet1;

    public int[] bulletDamage;

    public bool doubleShoot = false;

    public TextMeshProUGUI[] bulletDamageText;

    public Renderer gunRenderer;
    
    void Awake(){
        bulletDamage = new int[4];
        bulletDamage[0]=0;
        bulletDamage[1]=1;
        bulletDamage[2]=2;
        bulletDamage[3]=3;
       
    }

    IEnumerator Start() {
        
        
    while(doubleShoot==false) {
        yield return new WaitForSeconds(Singleton.instance.fireRate);
        ShootBullet();
        
    }

    while(doubleShoot==true) {
        yield return new WaitForSeconds(Singleton.instance.fireRate);
        ShootDoubleBullet();
        
    }

    }

    

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            if(this.gameObject.transform.position.x > leftBoundary) {
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            }
            
        } if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            if(this.gameObject.transform.position.x < rightBoundary) {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
            }
        }
        
        if(Singleton.instance.gunPower>=3 && Singleton.instance.gunPower<5)
        {
            gunRenderer.material.color=Color.red;

        } 
        else if (Singleton.instance.gunPower>=5 && Singleton.instance.gunPower<10) 
        {
            gunRenderer.material.color=Color.black;
        } else if (Singleton.instance.gunPower>=10) 
        {
            gunRenderer.material.color=Color.magenta;
        }


        bulletDamageText[0].text = bulletDamage[0].ToString();
        bulletDamageText[1].text = bulletDamage[1].ToString();
        bulletDamageText[2].text = bulletDamage[2].ToString();
        bulletDamageText[3].text = bulletDamage[3].ToString();

    }

    void ShootBullet(){
        GameObject TempBullet = Instantiate(bullet1, transform);
        TempBullet.transform.position = transform.position;

        int tempBulletDamage = bulletDamage[0];
            bulletDamage[0] = bulletDamage[1];
            bulletDamage[1] = bulletDamage[2];
            bulletDamage[2] = bulletDamage[3];
            bulletDamage[3] = tempBulletDamage;

    }

    void ShootDoubleBullet(){
        GameObject TempBullet1 = Instantiate(bullet1, transform);
        GameObject TempBullet2 = Instantiate(bullet1, transform);
        TempBullet1.transform.position = transform.position + new Vector3(0.5f,0.0f,0.0f);
        TempBullet2.transform.position = transform.position + new Vector3(-0.5f,0.0f,0.0f);

        int tempBulletDamage = bulletDamage[0];
            bulletDamage[0] = bulletDamage[1];
            bulletDamage[1] = bulletDamage[2];
            bulletDamage[2] = bulletDamage[3];
            bulletDamage[3] = tempBulletDamage;

    }
}
