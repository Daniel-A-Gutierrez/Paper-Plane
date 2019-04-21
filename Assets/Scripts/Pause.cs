using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject restart;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                GetComponent<PaperPlaneController>().enabled = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Time.timeScale = 0;
                GetComponent<PaperPlaneController>().enabled = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            restart.SetActive(!restart.activeSelf);
            exit.SetActive(!exit.activeSelf);
        }
    }
}
