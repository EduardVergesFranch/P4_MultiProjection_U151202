using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make the pick up objects rotate
public class Rotator : MonoBehaviour
{
    bool up;
   
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(13, 30, 45) * Time.deltaTime);
       
    }
}
