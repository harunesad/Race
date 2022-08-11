using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRamp : MonoBehaviour
{
    public static EnemyRamp Instance;
    [SerializeField] Transform smallRampAI, mediumRampAI, bigRampAI;

    private float small, medium, big;
    private float nearRamp;
    private float posX;

    public bool fixPosSmall = false, fixPosMedium = false, fixPosBig = false;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (fixPosSmall)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(smallRampAI.position.x, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (fixPosMedium)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(mediumRampAI.position.x, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
        if (fixPosBig)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(bigRampAI.position.x, transform.position.y, transform.position.z), Time.deltaTime * 10f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RampFinish"))
        {
            posX = transform.position.x;
            small = smallRampAI.position.x - posX;
            medium = mediumRampAI.position.x - posX;
            big = bigRampAI.position.x - posX;
            nearRamp = Mathf.Min(Mathf.Abs(small), Mathf.Abs(medium), Mathf.Abs(big));
            if (nearRamp == Mathf.Abs(small))
            {
                fixPosSmall = true;
            }
            if (nearRamp == Mathf.Abs(medium))
            {
                fixPosMedium = true;
            }
            if (nearRamp == Mathf.Abs(big))
            {
                fixPosBig = true;
            }
        }
    }
}
