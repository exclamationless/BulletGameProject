using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleScipt : MonoBehaviour
{
    public int obstaclePower;

    public TextMeshProUGUI obstacleText;
    
    void Start()
    {
        gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = false;
        transform.parent.GetChild(0).gameObject.SetActive(false);

        obstaclePower = Random.Range(-10, -3);
    }

    void Update()
    {
        obstacleText.text = obstaclePower.ToString();
        if(obstaclePower>=0){
            gameObject.GetComponentInParent<GateScipt>().GateCollider.enabled = true;
            transform.parent.GetChild(0).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("Obstacle Recived Bulllet");
            obstaclePower = obstaclePower + other.gameObject.GetComponent<BulletScript>().tempBulletDamage;
            other.gameObject.SetActive(false);
            
        }

    }
}
