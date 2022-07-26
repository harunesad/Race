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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nitro"))
        {
            nitroCount++;
            nitroCountText.text = "" + nitroCount;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Boost"))
        {
            StartCoroutine(Boost());
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.CompareTag("Ramp"))
        {
            fixrotation=true;
            Debug.Log("Debug");
            // this.gameObject.transform.rotation=Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5);
        }
    }
    IEnumerator Boost()
    {

        PlayerCarForward.Instance.speed = 10;
        yield return new WaitForSecondsRealtime(2);
        PlayerCarForward.Instance.speed = 5;
    }
}
