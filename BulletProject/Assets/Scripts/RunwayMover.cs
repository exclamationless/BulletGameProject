using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayMover : MonoBehaviour
{
    
    public int RunwaySpeed = 4;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * RunwaySpeed * Time.deltaTime);
    }
}
