using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    [SerializeField] Text nitroCountText;
    int nitroCount;
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
            Destroy(other.gameObject, 0.2f);
        }
        if (other.gameObject.CompareTag("Boost"))
        {
            StartCoroutine(Boost());
        }
    }
    IEnumerator Boost()
    {
        PlayerCarForward.Instance.speed = 800;
        yield return new WaitForSecondsRealtime(2);
        PlayerCarForward.Instance.speed = 400;
    }
}
