using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject scare;
    public GameObject flashLight, soundWARRR;
    GameObject zombie;
    float distance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //zombie = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        zombie = GameObject.FindGameObjectWithTag("Enemy");

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 range = zombie.transform.position - flashLight.transform.position;
        //Debug.Log(range.z);

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit, distance))
        {
            // If the ray hits an obstacle, change direction
            if (hit.collider.CompareTag("WallCollider") )
            {
                return;
            }
            else if (range.z < 0.5f && flashLight.activeSelf)
            {
                soundWARRR.SetActive(true);
                Destroy(zombie);
                playerMovement.enabled = false;
                Debug.Log("NearZombie");
                scare.SetActive(true);
                Invoke("SceneLoad", 3f);
            }
            
        }
    }

    void SceneLoad()
    {
        MazeGenerator.lvl = 0;
        SceneManager.LoadScene(3);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            soundWARRR.SetActive(true);
            Destroy(zombie);
            playerMovement.enabled = false;
            Debug.Log("Flashlight Detected");
            scare.SetActive(true);
            Invoke("SceneLoad", 2f);
        }
    }
}
