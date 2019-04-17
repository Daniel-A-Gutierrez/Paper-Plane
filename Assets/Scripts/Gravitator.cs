using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitator : MonoBehaviour
{
    public Vector3 origin = Vector3.zero;
    public float Gravity;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce((origin - transform.position).normalized * Gravity, ForceMode.Acceleration);
    }
}
