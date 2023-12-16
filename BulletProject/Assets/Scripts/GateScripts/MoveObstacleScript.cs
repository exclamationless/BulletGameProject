using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveObstacleScript : ObjectsAbstract
{
    public int moveObstaclePower;
    
    void Start()
    {
        moveObstaclePower = Random.Range(-10, -3);
    }

    void Update()
    {
        objectText.text = moveObstaclePower.ToString();
        if(moveObstaclePower>=0){
            this.gameObject.SetActive(false);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Obstacle Recived Bulllet");
            moveObstaclePower = moveObstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            other.gameObject.SetActive(false);
        }

    }
}
