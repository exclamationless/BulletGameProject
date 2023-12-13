using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveObstacleScript : MonoBehaviour
{
    public int moveObstaclePower;

    public TextMeshProUGUI moveObstacleText;
    
    void Start()
    {
        moveObstaclePower = Random.Range(-10, -3);
    }

    void Update()
    {
        moveObstacleText.text = moveObstaclePower.ToString();
        if(moveObstaclePower>=0){
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Obstacle Recived Bulllet");
            moveObstaclePower = moveObstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            other.gameObject.SetActive(false);
            
        }

    }
}
