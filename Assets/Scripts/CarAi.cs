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
    private void Awake()
    {
        Instance = this;
        spawner = GetComponentInChildren<Spawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0;
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
        
    }
    void Boost(Collider other)
    {
        if (other.gameObject.CompareTag("Boost") && !rampAI)
        {

            StartCoroutine(BoostTime());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectingNitro(other);
        Boost(other);
    }
    private void Movement()
    {
        transform.Translate(xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
        if (spawner.nitroEnemys.Count > 0)
        {
            if (spawner.nitroEnemys[0].transform.position.x > transform.position.x)
            {
                xSpeed = 10f;
            }
            else if (spawner.nitroEnemys[0].transform.position.x < transform.position.x)
            {
                xSpeed = -10f;
            }
            float distance = Mathf.Abs(spawner.nitroEnemys[0].transform.position.x - transform.position.x);
            if (distance < 0.1f)
            {
                xSpeed = 0;
            }
        }
        

        if (fixedRotation)
        {
            Debug.Log("adad");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 10f);
        }
        
        
    }
    IEnumerator BoostTime()
    {
        rampAI = true;
        float zSpeedBeforeBoost = zSpeed;
        zSpeed = zSpeed * 2;
        yield return new WaitForSeconds(1f);
        zSpeed = zSpeedBeforeBoost;
        rampAI = false;
    }
}
