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

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float maxDisplacement = 3f;
    [SerializeField] private float maxPositionX = 4.5f;
    private Vector2 _anchorPosition;
    
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
        var inputX = GetInput();
            
        var displacementX = GetDisplacement(inputX);
            
        displacementX = SmoothOutDisplacement(displacementX);
            
        var newPosition = GetNewLocalPosition(displacementX);
            
        newPosition = GetLimitedLocalPosition(newPosition);

        transform.localPosition = newPosition;

        /*Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mouseWorldPosition = Input.mousePosition;
        mouseWorldPosition.y = transform.position.y;
        mouseWorldPosition.z = transform.position.z;
        if(mouseWorldPosition.x<=0){
            mouseWorldPosition.x = -4.5f;
            }else if(mouseWorldPosition.x>0.0f && mouseWorldPosition.x < ((Screen.width/7)*3))
            {
                mouseWorldPosition.x = -4.5f;}
            else if(mouseWorldPosition.x>=((Screen.width/7)*3) && mouseWorldPosition.x < ((Screen.width/7)*4))
            {
                mouseWorldPosition.x = transform.position.x;}
            else if(mouseWorldPosition.x>=((Screen.width/7)*4) && mouseWorldPosition.x < Screen.width)
            {
                mouseWorldPosition.x = 4.5f;}
            else if(mouseWorldPosition.x>=Screen.width)
            {
                mouseWorldPosition.x = 4.5f;}

            transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, 0.04f);*/
        
        if(Singleton.instance.gunPower>=3 && Singleton.instance.gunPower<5)
        {
            gunRenderer.material.color=Color.red;
        } 
        else if (Singleton.instance.gunPower>=5 && Singleton.instance.gunPower<10) 
        {
            gunRenderer.material.color=Color.black;
        } 
        else if (Singleton.instance.gunPower>=10) 
        {
            gunRenderer.material.color=Color.magenta;
        }


        bulletDamageText[0].text = bulletDamage[0].ToString();
        bulletDamageText[1].text = bulletDamage[1].ToString();
        bulletDamageText[2].text = bulletDamage[2].ToString();
        bulletDamageText[3].text = bulletDamage[3].ToString();

    }


    private Vector3 GetLimitedLocalPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, -maxPositionX, maxPositionX);
        return position;
    }

    private Vector3 GetNewLocalPosition(float displacementX)
    {
        var lastPosition = transform.localPosition;
        var newPositionX = lastPosition.x + displacementX;
        var newPosition = new Vector3(newPositionX, lastPosition.y, lastPosition.z);
        return newPosition;
    }

    private float GetInput()
    {
            var inputX = 0f;
            if (Input.GetMouseButtonDown(0))
            {
                _anchorPosition = Input.mousePosition;
            }

            else if (Input.GetMouseButton(0))
            {
                inputX = (Input.mousePosition.x - _anchorPosition.x);
                _anchorPosition = Input.mousePosition;
            }
            return inputX;
    }

    private float GetDisplacement(float inputX)
    {
        var displacementX = 0f;
        displacementX = inputX * Time.deltaTime;
        return displacementX;
    }
    private float SmoothOutDisplacement(float displacementX)
    {
        return Mathf.Clamp(displacementX, -maxDisplacement, maxDisplacement);
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
