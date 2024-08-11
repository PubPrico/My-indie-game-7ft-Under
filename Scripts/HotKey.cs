using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotKey : MonoBehaviour
{
    public GameObject[] inventoryKey;
    // Start is called before the first frame update
    void Start()
    {
        inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.1f);
        inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("2"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("3"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("4"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("5"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("6"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.05f);
        }
        if(Input.GetButtonDown("7"))
        {
            inventoryKey[0].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[1].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[2].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[3].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[4].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[5].GetComponent<Image>().color = new Color(1,1,1,0.05f);
            inventoryKey[6].GetComponent<Image>().color = new Color(1,1,1,0.2f);
        }
    }
}
