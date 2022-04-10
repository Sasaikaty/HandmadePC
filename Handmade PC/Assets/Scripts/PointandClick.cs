using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PointandClick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform canvas;
    public static GameObject dragObj;
    public GameObject placeObj;
    public bool draged = false;
    public GameObject text;
    public float Timer =3;
    public Vector3 vec;
    public float scale;
    public GameObject changeObj;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(draged == true)
        {
            var rotate = gameObject.transform.rotation;
            var rt = Quaternion.Euler(0, 0, 90);
            if (Input.GetKeyUp(KeyCode.R))
            {
                rotate *= rt;
                gameObject.transform.rotation = rotate;
            }
        }
        if(text.activeSelf == true)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                text.SetActive(false);
                Timer = 3f;
            }
        }
        vec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragObj = gameObject;
        if (dragObj.transform.parent != canvas)
        {
            dragObj.transform.localScale = dragObj.transform.localScale * scale;
        }
        dragObj.transform.SetParent(canvas);
        draged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (vec.x > 0 && vec.x < Screen.width && vec.y> 0 && vec.y < Screen.height)
        {
            dragObj.transform.position = Input.mousePosition;
        }
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        if (dragObj.transform.position.x <= placeObj.transform.position.x+28 && dragObj.transform.position.x >= placeObj.transform.position.x - 28 && dragObj.transform.position.y <= placeObj.transform.position.y + 28 && dragObj.transform.position.y >= placeObj.transform.position.y - 28)
        {    
            if (dragObj.transform.rotation == placeObj.transform.rotation && placeObj.GetComponent<PointandClick>().enabled == false && placeObj.activeSelf== true)
            {
                if (gameObject.tag == "Processor")
                {
                    changeObj.SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                {
                    if(gameObject.tag == "Cooler")
                    {
                        changeObj.SetActive(true);
                    }
                    dragObj.transform.position = placeObj.transform.position;
                    GetComponent<PointandClick>().enabled = false;
                }   
            }            
            else
            {
                text.SetActive(true);
            }
        }
        
        draged = false;
        dragObj = null;
    }
}
