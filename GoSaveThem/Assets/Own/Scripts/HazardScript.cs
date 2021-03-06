﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{   
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("player in trigger");

        if (other.tag == "Player")
        {
            Debug.Log("player in hazard");
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            other.GetComponent<Movement>().Die();
            
            Destroy(this.gameObject, 0.25f);

            Destroy(explosion, 1.5f);
        }

    }
}
