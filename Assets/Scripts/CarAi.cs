using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CarAi : MonoBehaviour
{
    public static CarAi Instance;
    public bool fixedRotation = false;
    [SerializeField] Transform targetPositionTranform;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float xSpeed = 0;
    public float zSpeed = 5;
    public int nitroCount;
    public Text nitroCountText;
    private bool rampAI = false;
    Spawner spawner;
    float aiBoostNeedNitro = 2;
    //float zSpeedBeforeBoost;
    public bool aiForwardMove = true;
    bool collideWithGround = false;
    float speedBeforeOil;
    private void Awake()
    {
        Instance = this;
        spawner = GetComponentInChildren<Spawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0;
        //zSpeedBeforeBoost = zSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();    
    }
    void CollectingNitro(Collider other)
    {
        if (other.gameObject.CompareTag("NitroEnemy"))
        {
            if (spawner.nitroEnemys.Count > 0)
            {
                nitroCount++;
                nitroCountText.text = "" + nitroCount;
                spawner.nitroEnemys.Remove(spawner.nitroEnemys[0]);
                targetPositionTranform = null;
                Destroy(other.gameObject);
                if (targetPositionTranform == null && spawner.nitroEnemys.Count > 0)
                {
                    targetPositionTranform = spawner.nitroEnemys[0].transform;
                }
            }
            if (spawner.nitroEnemys2.Count > 0 && collideWithGround)
            {
                nitroCount++;
                nitroCountText.text = "" + nitroCount;
                spawner.nitroEnemys2.Remove(spawner.nitroEnemys2[0]);
                targetPositionTranform = null;
                Destroy(other.gameObject);
                if (targetPositionTranform == null && spawner.nitroEnemys2.Count > 0)
                {
                    targetPositionTranform = spawner.nitroEnemys2[0].transform;
                }
            }

        }
        if (other.gameObject.CompareTag("Nitro"))
        {
            Destroy(other.gameObject);
        }
        
    }
    void Boost(Collider other)
    {
        if (other.gameObject.CompareTag("Boost") && !rampAI)
        {
            Debug.Log("boost");
            StartCoroutine(BoostTime());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectingNitro(other);
        Boost(other);
        if (other.gameObject.CompareTag("Ground"))
        {
            collideWithGround = true;
            Debug.Log(collideWithGround);
        }
        if (other.gameObject.CompareTag("Oil"))
        {
           StartCoroutine(Oil());
        }

    }
    private void Movement()
    {
        if (aiForwardMove)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
        }
        else
        {
            zSpeed = 0;
        }
        if (spawner.nitroEnemys.Count > 0)
        {
            float distance = Mathf.Abs(spawner.nitroEnemys[0].transform.position.x - transform.position.x);
            if (spawner.nitroEnemys[0].transform.position.x > transform.position.x)
            {
                xSpeed = 10f;
            }
            else if (spawner.nitroEnemys[0].transform.position.x < transform.position.x)
            {
                xSpeed = -10f;
            }

            if (distance < 0.1f)
            {
                xSpeed = 0;
            }

        }
        else if(!collideWithGround)
        {
            
            xSpeed = 0;
        }
        if (collideWithGround)
        {
            if (spawner.nitroEnemys2.Count > 0)
            {
                float distance = Mathf.Abs(spawner.nitroEnemys2[0].transform.position.x - transform.position.x);
                if (spawner.nitroEnemys2[0].transform.position.x > transform.position.x)
                {
                    xSpeed = 10f;
                }
                else if (spawner.nitroEnemys2[0].transform.position.x < transform.position.x)
                {
                    xSpeed = -10f;
                }

                if (distance < 0.1f)
                {
                    xSpeed = 0;
                }

            }
        }
        
        

        if (fixedRotation)
        {
            Debug.Log("adad");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 7);
        }
        
        
    }
    IEnumerator BoostTime()
    {
        rampAI = true;
        
        if (nitroCount >= aiBoostNeedNitro)
        {
            nitroCount -= 2;
            nitroCountText.text = "" + nitroCount;
            zSpeed = zSpeed + 5;
        }
        yield return new WaitForSeconds(2f);
        //zSpeed = zSpeedBeforeBoost;
        zSpeed = zSpeed - 5;
        rampAI = false;
    }
    IEnumerator Oil()
    {
        speedBeforeOil = zSpeed;
        if (zSpeed <= 10f)
        {
            zSpeed -= 3f;
        }
        else if(zSpeed > 10f && zSpeed < 15f)
        {
            zSpeed -= 5f;
        }
        else if(zSpeed > 15f)
        {
            zSpeed -= 8f;
        }
        
        yield return new WaitForSeconds(1.3f);
        zSpeed = speedBeforeOil;

    }


}
