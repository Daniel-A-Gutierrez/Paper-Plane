using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    public GameObject playagain;
    public GameObject youlose;
    public GameObject youwin;
    public GameObject wincube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "winner")
        {
            youwin.SetActive(true);
            wincube.GetComponent<AudioSource>().volume = 0f;
            
        }
        else if(collision.gameObject.tag == "not winner")
        {
            youlose.SetActive(true);
        }
        GetComponent<PaperPlaneController>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
        playagain.SetActive(true);

        Time.timeScale = 0;
    }

}
