using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void loadscene()
    {    
        SceneManager.LoadScene("SampleScene");
    }
    public void exit()
    {
        Application.Quit();
    }
}