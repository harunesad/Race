using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    [SerializeField] Text nitroCountText;
    public static Trigger Instance;
    int nitroCount;
    public bool fixrotation=false;
    public bool ramped=false;
    public float firstSpeed;

    void Awake() 
    {
        Instance = this;
    }
    void Start()
    {
        nitroCountText.text = "" + nitroCount;
    }
    void Update()
    {

        //  if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        // {
        //     Debug.Log("Bounds intersecting");
        // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nitro"))
        {
            nitroCount++;
            nitroCountText.text = "" + nitroCount;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("NitroEnemy"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Boost")&&!ramped)
        {
            StartCoroutine(Boost(1.5f));
            
        }

        if (other.gameObject.CompareTag("Ground")&&fixrotation)
        {
            SwerveSystem.Instance1.moveable=true;
            Debug.Log("Ground değdi");
            PlayerCarForward.Instance.speed = firstSpeed;
        }
    }

    //  private void OnCollisionEnter(Collision other) 
    // {
    //     if (other.gameObject.CompareTag("Ramp")&&!ramped)
    //     {
    //        firstSpeed=PlayerCarForward.Instance.speed;
    //         RampBoost(1.5f);
    //         ramped=true;
    //     }


    // }

    IEnumerator Boost(float speed)
    {
        ramped=true;
        firstSpeed=PlayerCarForward.Instance.speed;
        PlayerCarForward.Instance.speed *= speed;
        yield return new WaitForSecondsRealtime(2);
        PlayerCarForward.Instance.speed =firstSpeed;
        ramped=false;
    }



}
