using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoost : MonoBehaviour
{
    float posX, posZ;
    [SerializeField] float minPosX, maxPosX;
    [SerializeField] float minPosZ, maxPosZ;
    void Start()
    {
        posX = Random.Range(minPosX, maxPosX);
        posZ = Random.Range(minPosZ, maxPosZ);
        Debug.Log(posZ);
        transform.localPosition = new Vector3(posX, 0, posZ);
    }
}
