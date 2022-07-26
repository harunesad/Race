using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject playerCar;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerCar.transform.position + offset, Time.deltaTime * 5);
    }
}
