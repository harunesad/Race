using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOil : MonoBehaviour
{
    float posX, posZ;

    [SerializeField] float minPosX, maxPosX;
    [SerializeField] float minPosZ, maxPosZ;

    [SerializeField] Transform boost;
    void Awake()
    {
        RandomSpawn();
    }
    private void Update()
    {
        if (Vector3.Distance(boost.position, this.transform.position) < 10f)
        {
            RandomSpawn();
        }
    }
    void RandomSpawn()
    {
        posX = Random.Range(minPosX, maxPosX);
        posZ = Random.Range(minPosZ, maxPosZ);
        transform.localPosition = new Vector3(posX, 0, posZ);
    }
}
