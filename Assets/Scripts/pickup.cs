using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int value;
    public float rotateSpeed;
    public GameObject pick;
    public AudioSource tickSource;


    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.Collect(value, gameObject);
        this.GetComponent<Renderer>().enabled = false;
        //this.GetComponent<Collider>().enabled = false;
        tickSource.Play();
        Destroy(this.gameObject, 1.6f);
        //this.gameObject.SetActive(false);
    }
}
