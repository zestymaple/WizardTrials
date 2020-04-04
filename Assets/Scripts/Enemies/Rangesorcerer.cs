using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rangesorcerer : MonoBehaviour
{
    public float speed;
    public float startMovingDistance;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < startMovingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 0 * Time.deltaTime);


            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, 0 * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                //Quanternion = no rotation for projectile.
                //Instantiate(projectile, transform.position, Quaternion.identity);
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
