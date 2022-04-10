using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Inventory;
    public bool inventory = false;
    public GameObject Cum1;
    public GameObject Cum2;
    public GameObject CFB;
    public GameObject Cooler;
    public int Click;
    public bool Cool;
    public bool Legs;
    public bool Mat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InventoryActivate();
        if (Cooler.GetComponent<PointandClick>().enabled == false)
        {
            inventory = false;
            Inventory.GetComponent<Animator>().SetBool("Isopen", false);
        }
        if(Click >= 4 && Cool == true)
        {
            CFB.SetActive(true);
            Click = 0;
            Cool = false;
        }


        if(Click >= 6)
        {
            if(Legs == true)
            {
                Cooler.SetActive(true);
                Click = 0;
                Cooler = GameObject.Find("Mat");
                Mat = true;
                Legs = false;
            }
            if(Mat == true)
            {
                Click = 0;
                Cooler = GameObject.Find("Videocard");
            }
        }
    }
    void InventoryActivate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory == false)
            {
                inventory = true;
                Inventory.GetComponent<Animator>().SetBool("Isopen", true);
            }
            else
            {
                inventory = false;
                Inventory.GetComponent<Animator>().SetBool("Isopen", false);
            }
        }
    }
    public void CumPaste()
    {
        Cum2.SetActive(true);
        Cum1.SetActive(false);
    }
    public void Clicker()
    {
        Click += 1;  
    }
    public void NewScene()
    {
        SceneManager.LoadScene("Secondscene");
    }
}
