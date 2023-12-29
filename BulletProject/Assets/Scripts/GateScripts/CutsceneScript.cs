using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : Interactable
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

    public override void OnObjectEnter(Collider other)
    {
        if(other.TryGetComponent(out BulletDamageObjectScript bulletDO) && currentBulletNum < 4){
            if(isTagAdded){
            triggerListenerRef.tagList.Add(other.tag);
            isTagAdded=false;
            }
            BulletHolder[currentBulletNum] = other.gameObject.GetComponent<BulletDamageObjectScript>().bulletDamageNum;
            currentBulletNum++;
            other.gameObject.GetComponent<BulletDamageObjectScript>().isReverseMoving = false;
            other.transform.position = new Vector3(currentBulletPosX, 1.5f, transform.position.z);
            other.gameObject.GetComponent<RunwayMover>().RunwaySpeed = 4;
            currentBulletPosX = currentBulletPosX+2;

            other.gameObject.GetComponent<BulletDamageObjectScript>().bulletDamageObjectCollider.enabled = false;
        }
        else if(other.TryGetComponent(out BulletDamageObjectScript bulletDO2) && currentBulletNum >= 4){
            other.gameObject.SetActive(false);
        }
            
        
    }

    public override void colliderAdder()
    {
        base.colliderAdder();

    }

}
