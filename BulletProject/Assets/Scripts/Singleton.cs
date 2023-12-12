using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    public float bulletRange =1f;
    public float fireRate = 1f;
    public int gunPower=0;
    public int playerMoney=0;
    public int levelCounter=0;

    public GameObject textPanel;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gunPowerText;

    private void Awake()
    {
        bulletRange =1f;
        fireRate = 1f;

        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);

            

        }
           
        else{
            Destroy(gameObject);

        }
            
    }

    void Update(){
        moneyText.text = playerMoney.ToString();
        levelText.text = "Level " + levelCounter.ToString();
        gunPowerText.text = "Gun Power: " + gunPower.ToString();

        

        if(bulletRange<=0.05f){
            bulletRange=0.05f;
        }

        if(fireRate<=0.3f){
            fireRate=0.3f;
        }
    }
}
