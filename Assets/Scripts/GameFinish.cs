using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
            Debug.Log("Player win");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerCarForward.Instance.forwardMove = false;
            CarAi.Instance.aiForwardMove = false;
            Debug.Log("ai win");
        }
    }
}
