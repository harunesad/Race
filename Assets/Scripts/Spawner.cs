using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject nitroPlayer;
    public GameObject nitroEnemy;
    public List<GameObject> nitroPlayers = new List<GameObject>();
    public List<GameObject> nitroEnemys = new List<GameObject>();
    public List<GameObject> nitroEnemys2 = new List<GameObject>();
    public float right_X = 2.5f;
    public float middle_X = 0f;
    public float left_X = -2.5f;
    public int i;
    void Start()
    {
        for (i = 2; i < 27; i++)  
        {
            int z=10*i;  //10
            object_clone(z);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        foreach (GameObject nitroPlayer in nitroPlayers.ToList())
        { 
            if (nitroPlayer == null)
            {
                nitroPlayers.Remove(nitroPlayer);
            }
            else 
            {
                
                if (nitroPlayer.transform.position.z<this.transform.position.z)
                {
                    // Debug.Log("Destroyed nitroPlayers");
                     Destroy(nitroPlayer,2f);
                    nitroPlayers.Remove(nitroPlayer);
                    
                }
            }
        }

        foreach (GameObject nitroEnemy in nitroEnemys.ToList())
        {
            if (nitroEnemy == null)
            {
                nitroEnemys.Remove(nitroEnemy);
            }
            else 
            {
                if (nitroEnemy.transform.position.z<this.transform.position.z)
                {
                    // Debug.Log("Destroyed nitroEnemy");
                    Destroy(nitroEnemy, 2f);
                    nitroEnemys.Remove(nitroEnemy);
                    
                    
                    
                }
            }
        }
        foreach (GameObject nitroEnemy in nitroEnemys2.ToList())
        {
            if (nitroEnemy == null)
            {
                nitroEnemys2.Remove(nitroEnemy);
            }
            else
            {
                if (nitroEnemy.transform.position.z < this.transform.position.z)
                {
                    // Debug.Log("Destroyed nitroEnemy");
                    Destroy(nitroEnemy);
                    nitroEnemys2.Remove(nitroEnemy);
                    


                }
            }
        }

    }

    IEnumerator Iobject_clone(float z_coordinate)
    {
        
        int randomNumber = Random.Range(0,100);
        if (randomNumber>0 && randomNumber<90)
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
        nitroPlayers.Add(new_clone);
        GameObject new_clone2 = Instantiate(object2);
        if (i < 15)
        {
            nitroEnemys.Add(new_clone2);
        }
        else
        {
            nitroEnemys2.Add(new_clone2);
        }
        
        int randomNumber = Random.Range(0,99);
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
