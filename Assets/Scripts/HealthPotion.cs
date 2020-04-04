using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public Animator Anim;
    public Player_getshit player;
    public int PotionValue;
    
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HealthPotionBig Collider Triggered");
        if (other.CompareTag("Player") && player.player_current_health != player.player_max_health)
        {
            Debug.Log("HealthPotionBig Taken");
            // Play Disappear Animation
            Anim.SetBool("Taken", true);
        }
    }

    public void PotionTaken()
    {
        // Destroy Potion Object
        Destroy(gameObject);
        // Update Player Health
        if (player.player_current_health == player.player_max_health)
        {
            return;
        }
        else
        {
            if (player.player_current_health + PotionValue >= player.player_max_health)
            {
                player.player_current_health = player.player_max_health;
            }
            else
            {
                player.player_current_health += PotionValue;   
            }
        }        
    }
}
