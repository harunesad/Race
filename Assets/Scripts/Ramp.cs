using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public float speedmultiply;
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + " entered Trigger tagged " + other.gameObject.name);
            SwerveSystem.Instance1.moveable=false;
           Trigger.Instance.firstSpeed=PlayerCarForward.Instance.speed;
            RampBoost(speedmultiply);
        }

        if (other.gameObject.CompareTag("NitroEnemy"))
        {
            Destroy(other.gameObject);
        }
        
    }
        private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger.Instance.fixrotation=true;
            // Debug.Log("Debug1");
            // if(other.gameObject.CompareTag("Ground"))
            // {   Debug.Log("Debug");
            //     PlayerCarForward.Instance.speed = firstSpeed;
            // }
            // this.gameObject.transform.rotation=Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5);
        }

    }

    void RampBoost(float speed)
    {
        Debug.Log("Hız arttırıldı");
        PlayerCarForward.Instance.speed *= speed;
    }
}
