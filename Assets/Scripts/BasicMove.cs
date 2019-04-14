using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float speed;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            transform.Translate(speed*-cam.transform.right,Space.World);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(speed*cam.transform.right,Space.World);
        if(Input.GetKey(KeyCode.W))
            transform.Translate(speed*cam.transform.forward,Space.World);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(speed*-cam.transform.forward,Space.World);
        if(Input.GetKey(KeyCode.Q))
            transform.Translate(speed*cam.transform.up,Space.World);
        if(Input.GetKey(KeyCode.E))
            transform.Translate(speed*-cam.transform.up,Space.World);
        transform.forward = new Vector3(GetComponent<Rigidbody>().velocity.x ,0 , GetComponent<Rigidbody>().velocity.z);
    }
}
