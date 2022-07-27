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
    private void Awake() {

        Instance1=this;
    }
    private void Update()
    {
        
        System();
    }
    public void System ()
    {
        // float xPos = Mathf.Clamp(playerCar.transform.rotation.y, -105, -75);
        //if (gameObject.transform.rotation.y < 0)
        //{
        //    gameObject.transform.Rotate(0, 0.5f, 0);
        //}
        //if (gameObject.transform.rotation.y > 0)
        //{
        //    gameObject.transform.Rotate(0, -0.5f, 0);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            rotate = false;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {

            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
            // if (moveFactorX > 0)
            // {
            //     playerCar.transform.Rotate(0, Time.deltaTime * 100, 0);
            //      if (playerCar.transform.rotation.y>-75)
            // {
            //     playerCar.transform.rotation=Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -75, 0), Time.deltaTime * 5);
            // }
            // }
            
            // else if (moveFactorX < 0)
            // {
            //     playerCar.transform.Rotate(0, -Time.deltaTime * 100, 0);
            //     if(playerCar.transform.rotation.y>-105)
            // {
            //      playerCar.transform.rotation=Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -105, 0), Time.deltaTime * 5);
            // }
            // }


            
            // else
            // {
            //     playerCar.transform.rotation=Quaternion.Euler(0,playerCar.transform.rotation.y,0);
            // }
            // playerCar.transform.rotation=Quaternion.Euler(playerCar.transform.rotation.x,xPos,playerCar.transform.rotation.z);
            //else if (moveFactorX == 0)
            //{
            //    playerCar.transform.rotation = Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 50);
            //}
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
            rotate = true;
        }
        if (rotate||Trigger.Instance.fixrotation)
        {
            playerCar.transform.rotation = Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5f);
        }

        
    }
}
