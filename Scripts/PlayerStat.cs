using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{

    public float maxHealth, maxStamina;
    bool staminaCD;
    public static float currentHealth = 100, currentStamina = 100;
    public Slider healthSlider, staminaSlider;
    public GameObject staminaFill;
    public GameObject blood;
    bool isHealing = false;
    // Start is called before the first frame update

    
    void Start()
    {

        healthSlider.maxValue = maxHealth;
        staminaSlider.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerStat.currentHealth);
        healthSlider.value = currentHealth;
        staminaSlider.value = currentStamina;

        //HEALTH
        if(Input.GetKeyDown(KeyCode.Z))
        {
            isHealing = false;
            PlayerStat.currentHealth -= 10;
        }
        

        //Health Control
        if(PlayerStat.currentHealth >= maxHealth)
        {
            isHealing = false;
            PlayerStat.currentHealth = 100;
        }
        if(PlayerStat.currentHealth <=0)
        {
            PlayerStat.currentHealth = 0;
        }

        if(PlayerStat.currentHealth <= 20)
        {
            blood.SetActive(true);
        }
        else
        {
            blood.SetActive(false);
        }


        //STAMINA
        if(PlayerStat.currentStamina <= 0)
        {
            staminaCD = true;
            
        }
        else if(PlayerStat.currentStamina >= 50)
        {
            staminaCD = false;
        }

        if(staminaCD)
        {
            staminaFill.GetComponent<Image>().color = new Color32(0, 55, 133, 130);
        }
        else if(!staminaCD)
        {
            staminaFill.GetComponent<Image>().color = new Color32(0, 105, 255, 130);
        }

        if(PlayerStat.currentStamina < maxStamina && staminaCD)
        {
            PlayerStat.currentStamina = PlayerStat.currentStamina + 3 * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && !staminaCD)
        {
            //Debug.Log(PlayerStat.currentStamina);
            PlayerStat.currentStamina = PlayerStat.currentStamina - 10 * Time.deltaTime;
        }
        else
        {
            if(currentStamina != maxStamina && !staminaCD)
            {
                PlayerStat.currentStamina = PlayerStat.currentStamina + 3 * Time.deltaTime;
            }
        }

        if(PlayerStat.currentStamina >= maxStamina)
        {
            PlayerStat.currentStamina = 100;
        }
        if(PlayerStat.currentStamina <= 0)
        {
            PlayerStat.currentStamina = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        PlayerStat.currentHealth -= damage;
        if(isHealing == false)
        {
            if(PlayerStat.currentHealth < maxHealth)
            {
                StartCoroutine(Heal());
            }
            
        }
    }

    IEnumerator Heal()
    {
        yield return new WaitForSeconds(5f);

        isHealing = true;
    }
}
