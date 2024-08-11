using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool canOpen;
    // Start is called before the first frame update
    void Start()
    {
        canOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter()
    {
        canOpen = true;
    }

    void OnTriggerExit()
    {
        canOpen = false;
    }
}
