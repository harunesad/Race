using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] Image levelBar;
    [SerializeField] GameObject playerCar;
    [SerializeField] GameObject finishLine;
    [SerializeField] float distance;
    [SerializeField] float distanceUpdate;
    void Start()
    {
        distance = finishLine.transform.position.z - playerCar.transform.position.z;
    }
    void Update()
    {
        distanceUpdate = distance / playerCar.transform.position.z;
        levelBar.fillAmount = 1 - 1 / Mathf.Abs(distanceUpdate);
    }
}
