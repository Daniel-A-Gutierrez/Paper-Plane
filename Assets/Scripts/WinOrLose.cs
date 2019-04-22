using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinOrLose : MonoBehaviour
{
    public GameObject youlose;
    public GameObject youwin;
    public GameObject wincube;
    public string[] insults =
    {
        "You suck.",
        "maybe try hearing",
        "Youre supposed to come towards the sound",
        "sorry if youre colorblind, nerd",
        "try unmuting.",
        "its mono audio btw",
        "Did you find me?",
        "scared of the dark?",
        "apostrophes are illegal",
        "Im sure you just spawned far away.",
        "there are wormholes.",
        "I didnt see you either.",
        "Were you close?",
        "Do you just prefer seeing the\n collision,seeing your body flying off into the dark, rather than pausing \nand restarting?",
        "At this point youre just fishing. I hope.",
        "you lose.",
        "give up",
        "Fail Faster",
        "its cold"
    };
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
            youlose.GetComponent<TextMeshProUGUI>().SetText(insults[Random.Range(0, insults.Length)]);
        }
        GetComponent<PaperPlaneController>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GetComponent<Pause>().enabled = false;

    }

    IEnumerator WaitToSlow()
    {
        yield return null;
        Time.timeScale = 1/60f;
    }

}
