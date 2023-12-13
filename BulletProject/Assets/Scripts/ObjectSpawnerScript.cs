using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    /*public GameObject bulletRangeGate;
    public GameObject fireRateGate;
    public GameObject bulletDamageObject;
    public GameObject doubleShootObject;
    public GameObject moveObstacleObject;
    public GameObject gameWinGate;*/

    public GameObject[] gatesObjects;

    public GameObject winObjectSet;

    private int object1Counter=0;
    private int object2Counter=0;
    private int objectsHorizontalValue1=10;
    private int objectsHorizontalValue2=210;
    private int winObjectHorizontalValue=430;

    private int winObjectCounter=0;
    

    void Start()
    {
        winObjectSet.GetComponent<WinObjectSetScript>().winObjectPowerMultiplier = 1;

        while(object1Counter<10){
            int randomIndex = Random.Range(0, gatesObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-4.2f, 4.2f) , 1.5f , objectsHorizontalValue1);
            Instantiate(gatesObjects[randomIndex], randomSpawnPosition , gatesObjects[randomIndex].transform.rotation);
            //GameObject TempBulletGate = Instantiate(bulletRangeGate, this.transform);
            //TempBulletGate.transform.position = randomSpawnPosition;
            object1Counter++;
            objectsHorizontalValue1 = objectsHorizontalValue1+20;
        }

        while(object2Counter<10){
            int randomIndex = Random.Range(0, gatesObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-4.2f, 4.2f) , 1.5f , objectsHorizontalValue2);
            Instantiate(gatesObjects[randomIndex], randomSpawnPosition , gatesObjects[randomIndex].transform.rotation);
            //GameObject TempBulletGate = Instantiate(bulletRangeGate, this.transform);
            //TempBulletGate.transform.position = randomSpawnPosition;
            object2Counter++;
            objectsHorizontalValue2 = objectsHorizontalValue2+20;
        }

        while(winObjectCounter<50){
            Vector3 randomSpawnPosition = new Vector3(0.0f , 1.5f , winObjectHorizontalValue);
            Instantiate(winObjectSet, randomSpawnPosition , winObjectSet.transform.rotation);
            winObjectCounter++;
            winObjectHorizontalValue = winObjectHorizontalValue + 4;
            winObjectSet.GetComponent<WinObjectSetScript>().winObjectPowerMultiplier = winObjectCounter*2;
            

        }

        
        
    


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
