using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCriatureBehavior : CreatureBehavior //using inheritance
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(50f);
        }
    }
}
