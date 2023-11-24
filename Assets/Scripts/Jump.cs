using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float JumpForce = 5f;
    public float groundDistance = 0.5f;

    Rigidbody rigidbody;

    void Awake(){
        rigidbody = GetComponent<Rigidbody>();

    }

    bool IsGrounded(){
        return Physics.Raycast(transform.position,Vector3.down,groundDistance);
    }
    void Update(){
        if(Input.GetButtonDown("Jump") && IsGrounded()){  
            rigidbody.velocity = Vector3.up*JumpForce;
        }
    }
}
