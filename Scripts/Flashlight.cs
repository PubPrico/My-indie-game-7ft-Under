using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public TMP_Text batText;
    public static float batFloat = 100f;
    int batInt;

    public GameObject flashLight;
    bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        batInt = Mathf.RoundToInt(Flashlight.batFloat);
        batText.text = batInt.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        batInt = Mathf.RoundToInt(Flashlight.batFloat);
        batText.text = batInt.ToString() + "%";

        if(isOn)
        {
            flashLight.SetActive(true);
            isOn = true;
            Flashlight.batFloat = Flashlight.batFloat - 0.5f * Time.deltaTime;
        }
        
    
        if(Input.GetMouseButtonDown(1))
        {
            if(isOn)
            {
                flashLight.SetActive(false);
                isOn = false;
            }
            else if(!isOn)
            {
                flashLight.SetActive(true);
                isOn = true;
            }
        }

        if(batInt <= 0)
        {
            flashLight.SetActive(false);
            isOn = false;
            batText.text = 0 + "%";
        }
        else if(batInt <=25)
        {
            light.intensity =0.25f;
        }
        else if(batInt <=50)
        {
            light.intensity =0.5f;
        }
        
        
    }
}
