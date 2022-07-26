using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;
    public GameObject playerCar;

    bool rotate = false;
    private void Update()
    {
        System();
    }
    public void System ()
    {
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
            if (moveFactorX > 0)
            {
                playerCar.transform.Rotate(0, Time.deltaTime * 100, 0);
            }
            else if (moveFactorX < 0)
            {
                playerCar.transform.Rotate(0, -Time.deltaTime * 100, 0);
            }
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
        if (rotate)
        {
            playerCar.transform.rotation = Quaternion.Lerp(playerCar.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 5);
        }
    }
}
