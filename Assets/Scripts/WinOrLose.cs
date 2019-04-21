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
            wincube.GetComponent<AudioSource>().volume = 0f;
            youwin.SetActive(true);
        }
        else if(collision.gameObject.tag == "not winner")
        {
            youlose.SetActive(true);
        }
        GetComponent<PaperPlaneController>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playagain.SetActive(true);
        GetComponent<Pause>().enabled = false;

    }

    IEnumerator WaitToSlow()
    {
        yield return null;
        Time.timeScale = 1/60f;
    }

}
