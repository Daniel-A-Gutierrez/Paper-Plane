using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationAxis;
    public float rotationSpeed;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero,Vector3.up,15);
        transform.forward = (Vector3.zero - transform.position);
        //transform.rotate
    }
}
