using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;
    public GameObject playerCar;
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
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
            //if (moveFactorX > 0)
            //{
            //    gameObject.transform.Rotate(0, 2.0f, 0);
            //}
            //if (moveFactorX < 0)
            //{
            //    gameObject.transform.Rotate(0, -2.0f, 0);
            //}
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
