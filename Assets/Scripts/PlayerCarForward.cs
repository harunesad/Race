using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarForward : MonoBehaviour
{
    public static PlayerCarForward Instance;
    Rigidbody playerRb;
    public float speed = 5;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        Instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        //playerRb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * 40);
        // playerRb.velocity = Vector3.forward * Time.deltaTime * speed;
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        // if (SwerveSystem.Instance1.moveFactorX > 0)
        //     {
        //         SwerveSystem.Instance1.playerCar.transform.Rotate(0, Time.deltaTime * 100, 0);
        //          if (SwerveSystem.Instance1.playerCar.transform.rotation.y>-75)
        //     {
        //         SwerveSystem.Instance1.playerCar.transform.rotation=Quaternion.Lerp(SwerveSystem.Instance1.playerCar.transform.rotation, Quaternion.Euler(0, -75, 0), Time.deltaTime * 15);
        //     }
        //     }
            
        //     else if (SwerveSystem.Instance1.moveFactorX < 0)
        //     {
        //         SwerveSystem.Instance1.playerCar.transform.Rotate(0, -Time.deltaTime * 100, 0);
        //         if(SwerveSystem.Instance1.playerCar.transform.rotation.y>-105)
        //     {
        //          SwerveSystem.Instance1.playerCar.transform.rotation=Quaternion.Lerp(SwerveSystem.Instance1.playerCar.transform.rotation, Quaternion.Euler(0, -105, 0), Time.deltaTime * 15);
        //     }
        //     }
    }
}
