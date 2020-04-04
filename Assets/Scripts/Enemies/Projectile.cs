using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float startMovingDistance;

    private Transform player;
    private Vector2 target;
    public GameObject OriginalObject;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < startMovingDistance)
        {
            //GameObject clone = (GameObject)GameObject.Instantiate(OriginalObject);
            this.GetComponent<Renderer>().enabled = true;
            
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
               // gameObject.SetActive(false);
                //StartCoroutine(DestroyProjectile());
                DestroyProjectile();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    
    //IEnumerator DestroyProjectile()
    void DestroyProjectile()
    {
        this.GetComponent<Renderer>().enabled = false;
        
        //Destroy(this.gameObject);

        /*yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);*/
    }
}
