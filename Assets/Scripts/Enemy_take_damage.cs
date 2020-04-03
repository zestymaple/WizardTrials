using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_take_damage : MonoBehaviour
{
    public Rigidbody2D rb;
    public int enemy_max_hp = 100;
    public int enemy_current_hp;
    public int player_reg_dmg;
    public int player_spc_dmg;
    public int player_proj_dmg;
    public float freeze_dur = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        enemy_current_hp = enemy_max_hp;
    }



    IEnumerator Freeze(float freeze_duration)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(freeze_duration);
        rb.constraints = RigidbodyConstraints2D.None;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //freeze location
        if (other.tag == "Player")
        {
            StartCoroutine(Freeze(freeze_dur));
        }

        //take damage
        if (other.tag == "Player_Hitbox_special")
        {
            Debug.Log("hit detected special");
            StartCoroutine(Freeze(freeze_dur));
            enemy_current_hp -= player_spc_dmg;
        }

        //take damage
        if (other.tag == "Player_Hitbox_regular")
        {
            Debug.Log("hit detected regular");
            StartCoroutine(Freeze(freeze_dur));
            enemy_current_hp -= player_reg_dmg;
        }

        //take damage
        if (other.tag == "Player_hitbox_projectile")
        {
            Debug.Log("hit detected projectille");
            enemy_current_hp -= player_proj_dmg;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
