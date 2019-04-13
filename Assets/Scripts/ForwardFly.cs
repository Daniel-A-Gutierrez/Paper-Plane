using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFly : MonoBehaviour
{
    public GameObject cam;
    Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        rb.AddForce(Vector3.down*rb.velocity.y*16, ForceMode.Force);
        //print(Physics.gravity);
    }
}
