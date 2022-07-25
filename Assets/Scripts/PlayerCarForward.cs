using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarForward : MonoBehaviour
{
    public static PlayerCarForward Instance;
    Rigidbody playerRb;
    public float speed = 400;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        Instance = this;
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        //playerRb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * 40);
        playerRb.velocity = Vector3.forward * Time.deltaTime * speed;
        //transform.Translate(Vector3.right * Time.deltaTime * 5);
    }
}
