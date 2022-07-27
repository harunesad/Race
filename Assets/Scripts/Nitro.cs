using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
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
        // Debug.Log(gameObject.tag + " entered Trigger tagged " + other.gameObject.tag);
        if (other.gameObject.tag == "Ramp")
        {
            // Debug.Log("Çakışıyor");
            Destroy(gameObject);
        }
    }
}
