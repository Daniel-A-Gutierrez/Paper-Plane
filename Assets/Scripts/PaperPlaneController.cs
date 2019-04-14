using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlaneController : MonoBehaviour
{
    public GameObject cam;
    Rigidbody rb;
    public float xdrag;
    public float ydrag;
    public float zdrag;
    public float turnSpeed;
    void Start()
    {
        cam.GetComponent<CameraFollow>().Start();//dont care if it runs twice, it needs to happen first
        transform.forward = transform.position - cam.transform.position + cam.GetComponent<CameraFollow>().offset;  
        rb = GetComponent<Rigidbody>(); 
        rb.velocity = transform.forward;

    }

    float GetAzimuthal()
    {
        Vector3 zx = new Vector3(1,0,1);

        float d = Vector3.Dot(vecm(zx,cam.transform.forward).normalized, vecm(zx,transform.forward).normalized);
        print(d);
        return Mathf.Acos(d);
    }

    float GetHAxis()
    {
        Vector3 zx = new Vector3(1,0,1);
        return Vector3.Dot(vecm(cam.transform.forward,zx).normalized, - Vector3.Cross(Vector3.up,transform.forward).normalized );
    }

    float GetVAxis()
    {
        return (cam.transform.forward.normalized - transform.forward.normalized).y;
    }

    Vector3 vecm(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x*b.x,a.y*b.y,a.z*b.z);
    }

    void Update()
    {
        //print(GetAzimuthal()*Mathf.Rad2Deg);
        //print(GetHAxis());
        //transform.RotateAround(transform.position,transform.forward,GetHAxis());
        transform.RotateAround(transform.position,Vector3.up,-turnSpeed*GetHAxis());
        transform.RotateAround(transform.position,transform.right,-turnSpeed*GetVAxis());

        rb.AddForce(-xdrag*Vector3.Dot(transform.right,rb.velocity) * transform.right);
        rb.AddForce(-ydrag*Vector3.Dot(transform.up, rb.velocity) * transform.up);
        rb.AddForce(-zdrag*Vector3.Dot(transform.forward,rb.velocity) * transform.forward);
        rb.AddForce(zdrag*Vector3.Dot(transform.forward,rb.velocity) * transform.up);

    }

}
