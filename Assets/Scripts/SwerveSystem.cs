using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    public float moveFactorX;
    public float MoveFactorX => moveFactorX;
    public GameObject playerCar;
    public float y1;

    bool rotate = false;

    public static SwerveSystem Instance1;
    public bool moveable=true;
    private void Awake() 
    {
        Instance1=this;
    }
    private void Update()
    {
        System();
    }
    public void System ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotate = false;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {

            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            rotate = true;
        }
        if (rotate||Trigger.Instance.fixrotation)
        {
            playerCar.transform.rotation = Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 7f);
        }
    }
}
