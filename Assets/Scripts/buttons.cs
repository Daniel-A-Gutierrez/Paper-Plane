using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class buttons : MonoBehaviour
{
    public GameObject MainMenuQuitButton;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void quit()
    {
        if(counter ==0 )
        {
            MainMenuQuitButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("no.");
            counter ++;
        }
        else if(counter == 1)
        {
            MainMenuQuitButton.SetActive(false);
        }
    }
}
