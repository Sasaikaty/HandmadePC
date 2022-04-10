using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateRAM : MonoBehaviour
{
    public bool yes;
    public Sprite t;
    public Sprite f;

    // Start is called before the first frame update
    void Start()
    {
        yes = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gameObject.GetComponent<PointandClick>().draged == true)
        {
            if(yes == false)
            {
                yes = true;
                gameObject.GetComponent<Image>().sprite = t;
            }
            else
            {
                yes = false;
                gameObject.GetComponent<Image>().sprite = f;
            }
        }
    }
}
