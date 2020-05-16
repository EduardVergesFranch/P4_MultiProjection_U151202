using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allow to the player to have double jump. When falling into the groun or wall the double jump is reloaded
public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGround;
    private int count; //double jump

    void Start()
    {
        count = 0;
        isGround = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGround)
        {
            if (Input.GetButtonDown("Jump")) //if player click space
            {
                rb.velocity = new Vector3(0.0f, 10f,0.0f);
                if(count >=1 ) isGround = false; // the player is able to do 2 jumps
                count = count + 1;
            }
        }

    }

    void OnCollisionEnter(Collision any) //when player falls check if it has fallen into the ground and reload the double jump
    {
        if (any.gameObject.CompareTag("Ground"))
        {
            
            isGround = true;
            count = 0;
        }
    }
}