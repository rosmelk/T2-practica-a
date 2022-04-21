using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHead : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Moneda1")
        {
            Destroy(other.gameObject);
        }
        
        else if (tag == "Moneda2")
        {
            Destroy(other.gameObject);
        }
    }
}
