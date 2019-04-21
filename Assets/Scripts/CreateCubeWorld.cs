using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeWorld : MonoBehaviour
{
    public GameObject temp;
    public float avg_mass;
    public float mass_dev;
    public float avg_energy;
    public float energy_dev;
    public float gravity_str;
    public float num_cubes;
    public Material winner;
    public bool menu = false;

    // Start is called before the first frame update
    void Start()
    {

        //big things should move slow
        for (int i = 0; i < num_cubes; i++)
        {
            float mass = Random.Range(1, avg_mass * 2) ;
            float energy = Random.Range(1f, avg_energy*2);
            float rotational = Random.Range(0f, 1f) * energy;
            float potential = Random.Range(.5f, 1.5f) * energy; // if this were allowed to be too  low, things might clump at the center
            float translational = Random.Range(0f, 1f) * energy;

            Vector3 displacement_dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            Vector3 torque_dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            Vector3 trans_direction = Vector3.Cross(displacement_dir, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;

            float displacement_magnitude = potential / mass / gravity_str;
            float rot_speed = Mathf.Sqrt(rotational / (Mathf.Pow(mass, 4f / 3f) / 6f));  //R = iw^2  w = (R/i)^.5 = (energy/(ms^2/6))^.5
            float speed = Mathf.Sqrt(2 * translational / mass);

            GameObject go = Instantiate(temp, displacement_dir * displacement_magnitude, Quaternion.identity);
            go.transform.localScale *= Mathf.Pow(mass,1f/3f);
            go.GetComponent<Rigidbody>().AddForce(trans_direction * speed, ForceMode.VelocityChange);
            go.GetComponent<Rigidbody>().AddTorque(torque_dir*rot_speed, ForceMode.VelocityChange);
            if(i == num_cubes - 1)
            {
                go.GetComponent<MeshRenderer>().material = winner;
                go.tag = "winner";
                go.GetComponent<AudioSource>().enabled = true;
                go.GetComponent<NoiseCue>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<WinOrLose>().wincube = go;
                if(menu)
                {
                    go.GetComponent<Rigidbody>().AddForce(-trans_direction * speed, ForceMode.VelocityChange);
                    go.GetComponent<Gravitator>().Gravity = 0;
                    go.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
                    go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    go.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    go.GetComponent<AudioSource>().volume = .25f;
                    go.transform.Translate(10,4,20);
                    go.GetComponent<Rigidbody>().AddTorque(-.9f*torque_dir*rot_speed, ForceMode.VelocityChange);
                    go.transform.localScale = Vector3.one*2;
                }
            }

        }
    }

}
