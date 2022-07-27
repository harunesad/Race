using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject nitroPlayer;
    public GameObject nitroEnemy;
    public GameObject[] nitroPlayers;
    public GameObject[] nitroEnemys;
    float right_X = 2.5f;
    float middle_X = 0f;
    float left_X = -2.5f;
    void Start()
    {
        for (int i = 2; i < 15; i++)  
        {
            int z=10*i;  //10
            object_clone(z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nitroPlayers = GameObject.FindGameObjectsWithTag("Nitro");
        nitroEnemys = GameObject.FindGameObjectsWithTag("NitroEnemy");
        foreach (GameObject nitroPlayer in nitroPlayers)
        {
            if (nitroPlayer.transform.position.z<SwerveSystem.Instance1.playerCar.transform.position.z)
            {
                // Debug.Log("Destroyed nitroPlayers");
                Destroy(nitroPlayer,2f);
            }
        }

        foreach (GameObject nitroEnemy in nitroEnemys)
        {
            if (nitroEnemy.transform.position.z<SwerveSystem.Instance1.playerCar.transform.position.z)
            {
                // Debug.Log("Destroyed nitroEnemy");
                Destroy(nitroEnemy,2f);
            }
        }

        // if (nitroEnemys.transform.position.z<SwerveSystem.Instance1.playerCar.transform.position.z)
        // {
        //     Destroy(nitroEnemys,0f);
        //     Debug.Log("Destroyed nitroEnemys");
        // }
    }

    IEnumerator Iobject_clone(float z_coordinate)
    {
        
        int randomNumber = Random.Range(0,100);
        if (randomNumber>0 && randomNumber<75)
        {
            clone(nitroPlayer,nitroEnemy,z_coordinate);
        }
        yield return new WaitForSeconds(1f);
    }
    void object_clone(float z_coordinate)
    {
        StartCoroutine(Iobject_clone(z_coordinate));
    }

    void clone(GameObject object1,GameObject object2,float z_coordinate)
    {
        GameObject new_clone = Instantiate(object1);
        GameObject new_clone2 = Instantiate(object2);
        int randomNumber = Random.Range(0,99);
        Debug.Log(randomNumber);
        int randomforEnemy;
        if (randomNumber<33)
        {
           randomforEnemy=Random.Range(1,2);
           new_clone.transform.position = new Vector3(right_X, 0.2f, z_coordinate);
        }
        else if (randomNumber>33  && randomNumber<66)
        {
            if (randomNumber<50)
            {
                randomforEnemy=0;
            }
            else
            {
                randomforEnemy=3;
            }
             new_clone.transform.position = new Vector3(middle_X, 0.2f, z_coordinate);
        }
        else
        {
            randomforEnemy=Random.Range(0,1);
             new_clone.transform.position = new Vector3(left_X, 0.2f, z_coordinate);
        }


        //enemyNitro
        if (randomforEnemy==0)
        {
           new_clone2.transform.position = new Vector3(right_X, 0.2f, z_coordinate);
        }
        else if (randomforEnemy==1)
        {
             new_clone2.transform.position = new Vector3(middle_X, 0.2f, z_coordinate);
        }
        else
        {
             new_clone2.transform.position = new Vector3(left_X, 0.2f, z_coordinate);
        }




    }
}
