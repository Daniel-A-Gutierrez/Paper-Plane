using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseCue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        GetComponent<NoiseCue>().player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnEnable()
    {
        GetComponent<NoiseCue>().player = GameObject.FindGameObjectWithTag("Player");
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float current_distance = Vector3.Distance(transform.position, player.transform.position);
        sound.pitch = 3 / Mathf.Pow(current_distance,.2f);
    }
}
