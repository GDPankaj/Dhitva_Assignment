using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        var verticalMovement = Input.GetAxisRaw("Vertical");

        body.AddForce(horizontalMovement,verticalMovement,0, ForceMode.Force);
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($"Something Happened" + other.gameObject.name);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Something Happened" + collision.gameObject.name);
    }
}
