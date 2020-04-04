using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public Animator Anim;
    public Hero_Controller player;
    public int PotionValue;
    
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("StaminaPotion Collider Triggered");
        if (other.CompareTag("Player") && player.hero_current_mana != player.hero_max_mana)
        {
            Debug.Log("StaminaPotion Taken");
            // Play Disappear Animation
            Anim.SetBool("Taken", true);
        }
    }

    public void PotionTaken()
    {
        // Destroy Potion Object
        Destroy(gameObject);
        // Update Player Health
        if (player.hero_current_mana == player.hero_max_mana)
        {
            return;
        }
        else
        {
            if (player.hero_current_mana + PotionValue >= player.hero_max_mana)
            {
                player.hero_current_mana = player.hero_max_mana;
            }
            else
            {
                player.hero_current_mana += PotionValue;   
            }
        }        
    }
}
