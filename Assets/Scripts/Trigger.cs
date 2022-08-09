using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Text nitroCountText;
    float speedBeforeOil;
    public static Trigger Instance;
    public int nitroCount;
    public bool fixrotation=false;
    public bool ramped=false;
    //public float firstSpeed;
    float posX;
    public Transform smallRamp, mediumRamp, bigRamp;
    float small,medium,big;
    float nearRamp;
    public bool fixPosSmall = false, fixPosMedium = false, fixPosBig = false;
    float boostNeedNitro = 2;

    void Awake() 
    {
        Instance = this;
    }
    void Start()
    {
        nitroCountText.text = "" + nitroCount;
        //firstSpeed = PlayerCarForward.Instance.speed;
    }
    void Update()
    {

        //  if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        // {
        //     Debug.Log("Bounds intersecting");
        // }
        if (fixPosSmall)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(smallRamp.position.x, transform.position.y, transform.position.z), Time.deltaTime * 7.5f);
        }
        if (fixPosMedium)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(mediumRamp.position.x, transform.position.y, transform.position.z), Time.deltaTime * 7.5f);
        }
        if (fixPosBig)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(bigRamp.position.x, transform.position.y, transform.position.z), Time.deltaTime * 7.5f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nitro"))
        {
            nitroCount++;
            nitroCountText.text = "" + nitroCount;
            Destroy(other.gameObject);
            this.GetComponent<Spawner>().nitroPlayers.Remove(other.gameObject);
        }

        if (other.gameObject.CompareTag("NitroEnemy"))
        {
            
            Destroy(other.gameObject);
            this.GetComponent<Spawner>().nitroEnemys.Remove(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Boost")&&!ramped)
        {
            StartCoroutine(Boost(5));
            
        }

        if (other.gameObject.CompareTag("Ground")&&fixrotation)
        {
            SwerveSystem.Instance1.moveable=true;
            Debug.Log("Ground değdi");
            //PlayerCarForward.Instance.speed = firstSpeed;
        }
        if (other.gameObject.CompareTag("RampFinish"))
        {
            Debug.Log("dsa");
            SwerveSystem.Instance1.moveable = false;
            posX = transform.position.x;
            small = smallRamp.position.x - posX;
            medium = mediumRamp.position.x - posX;
            big = bigRamp.position.x - posX;
            nearRamp = Mathf.Min(Mathf.Abs(small), Mathf.Abs(medium), Mathf.Abs(big));
            //fixPos = true;
            if (nearRamp == Mathf.Abs(small))
            {
                Debug.Log("s");
                fixPosSmall = true;
            }
            if (nearRamp == Mathf.Abs(medium))
            {
                Debug.Log("s");

                fixPosMedium = true;
            }
            if (nearRamp == Mathf.Abs(big))
            {
                Debug.Log("s");
                fixPosBig = true;
            }
        }
        if (other.gameObject.CompareTag("Oil"))
        {

            StartCoroutine(Oil());
        }
    }

    IEnumerator Boost(float speed)
    {
        ramped = true;
        //firstSpeed = PlayerCarForward.Instance.speed;
        if (nitroCount >= boostNeedNitro)
        {
            nitroCount -= 2;
            nitroCountText.text = "" + nitroCount;
            PlayerCarForward.Instance.speed += speed;
        }
        yield return new WaitForSeconds(2f);
        PlayerCarForward.Instance.speed -= speed;
        //PlayerCarForward.Instance.speed =firstSpeed;
        ramped=false;
    }
    IEnumerator Oil()
    {
        speedBeforeOil = PlayerCarForward.Instance.speed;
        PlayerCarForward.Instance.speed -= 3f;
        yield return new WaitForSeconds(1.3f);
        PlayerCarForward.Instance.speed = speedBeforeOil;

    }



}
