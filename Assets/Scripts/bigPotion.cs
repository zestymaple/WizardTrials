﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigPotion : MonoBehaviour
{
    public Animator Anim;
    public Player_getshit playerH;
    public Hero_Controller playerM;
    public bool Health_OR_Mana;

    private int PotionValueH = 45;
    private int PotionValueM = 40;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.SetBool("Health_OR_Mana", Health_OR_Mana);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bigPotion Collider Triggered");

        if (Health_OR_Mana)
        {
            Debug.Log("Big Mana Potion Collider Triggered");
            if (other.CompareTag("Player") && playerM.hero_current_mana != playerM.hero_max_mana)
            {
                Debug.Log("Big Mana Potion Taken");
                // Play Disappear Animation
                Anim.SetBool("Taken", true);
            }
        }
        else
        {
            Debug.Log("Big Health Potion Collider Triggered");
            if (other.CompareTag("Player") && playerH.player_current_health != playerH.player_max_health)
            {
                Debug.Log("Big Health Potion Taken");
                // Play Disappear Animation
                Anim.SetBool("Taken", true);
            }
        }
    }

    // PotionTaken is called by the last frame of potionDisappear Animation
    public void PotionTaken()
    {
        // Destroy Potion Object
        Destroy(gameObject);

        if (Health_OR_Mana)
        {
            // Update Player Mana
            if (playerM.hero_current_mana == playerM.hero_max_mana)
            {
                return;
            }

            if (playerM.hero_current_mana + PotionValueM >= playerM.hero_max_mana)
            {
                playerM.hero_current_mana = playerM.hero_max_mana;
            }
            else
            {
                playerM.hero_current_mana += PotionValueM;
            }
        }
        else
        {
            // Update Player Health
            if (playerH.player_current_health == playerH.player_max_health)
            {
                return;
            }

            if (playerH.player_current_health + PotionValueH >= playerH.player_max_health)
            {
                playerH.player_current_health = playerH.player_max_health;
            }
            else
            {
                playerH.player_current_health += PotionValueH;
            }
        }
    }
}
