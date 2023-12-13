using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public BoxCollider cutsceneCollider;

    public int currentBulletNum = 0;
    private float currentBulletPosX = -3;

    public int[] BulletHolder;

    void Start()
    {
        BulletHolder = new int[4];
        cutsceneCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BulletDamageObject" && currentBulletNum < 4){
            BulletHolder[currentBulletNum] = other.gameObject.GetComponent<BulletDamageObjectScript>().bulletDamageNum;
            currentBulletNum++;

            other.gameObject.GetComponent<BulletDamageObjectScript>().isReverseMoving = false;
            other.transform.position = new Vector3(currentBulletPosX, 1.5f, transform.position.z);
            other.gameObject.GetComponent<RunwayMover>().RunwaySpeed = 4;
            currentBulletPosX = currentBulletPosX+2;

            other.gameObject.GetComponent<BulletDamageObjectScript>().bulletDamageObjectCollider.enabled = false;
        }
        else if(other.tag == "BulletDamageObject" && currentBulletNum >= 4){
            other.gameObject.SetActive(false);
        }
            
        
    }

}
