using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarForward : MonoBehaviour
{
    public static PlayerCarForward Instance;
    public float speed = 5;
    public bool forwardMove = true;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (forwardMove)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
