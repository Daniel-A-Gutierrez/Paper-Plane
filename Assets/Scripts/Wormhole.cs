using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public Vector3 toWhere;
    public Vector3 offset;
    void Start()
    {
        toWhere = offset + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position + Vector3.up,transform.forward, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = toWhere;
    }
}
