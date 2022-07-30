using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ramp : MonoBehaviour
{
    public float speedmultiply;
    public TextMeshProUGUI needNitroMultiply;
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           //Trigger.Instance.firstSpeed=PlayerCarForward.Instance.speed;
            RampBoostPlayer(speedmultiply);
            if (Trigger.Instance.nitroCount >= System.Convert.ToInt32(needNitroMultiply.text))
            {
                PlayerCarForward.Instance.forwardMove = true;
                Trigger.Instance.nitroCount = Trigger.Instance.nitroCount - System.Convert.ToInt32(needNitroMultiply.text);
                Trigger.Instance.nitroCountText.text = "" + Trigger.Instance.nitroCount;
            }
            else
            {
                PlayerCarForward.Instance.forwardMove = false;
            }
            Trigger.Instance.fixPosSmall = false;
            Trigger.Instance.fixPosMedium = false;
            Trigger.Instance.fixPosBig = false;
            Debug.Log(System.Convert.ToInt32(needNitroMultiply.text));
        }

        if (other.gameObject.CompareTag("NitroEnemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            RampBoostAI(speedmultiply);
            CarAi.Instance.nitroCount = CarAi.Instance.nitroCount - System.Convert.ToInt32(needNitroMultiply.text);
            CarAi.Instance.nitroCountText.text = "" + CarAi.Instance.nitroCount;
            EnemyRamp.Instance.fixPosSmall = false;
            EnemyRamp.Instance.fixPosMedium = false;
            EnemyRamp.Instance.fixPosBig = false;
            Debug.Log("sa");
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            CarAi.Instance.fixedRotation = true;
        }

    }

    void RampBoostPlayer(float speed)
    {
        PlayerCarForward.Instance.speed *= speed;
    }
    void RampBoostAI(float speed)
    {
        CarAi.Instance.zSpeed *= speed;
    }
}
