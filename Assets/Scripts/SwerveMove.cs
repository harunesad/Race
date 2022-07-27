using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMove : MonoBehaviour
{
    [SerializeField] private float swerveSpeed = 0.5f;
    public SwerveSystem swerveSystem;
    private void Awake()
    {
        
        swerveSystem = GetComponent<SwerveSystem>();
    }
    private void Update()
    {
        Move();
        MovementLimit();
    }
    public void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveSystem.MoveFactorX;
        if (swerveSystem.moveable)
        {
            swerveSystem.playerCar.transform.Translate(x: 0, y: 0, z: -swerveAmount);
        }
        
    }
    private void MovementLimit()
    {
        if(swerveSystem.playerCar.transform.position.x<-4)
        {
            swerveSystem.playerCar.transform.position=new Vector3(-4,swerveSystem.playerCar.transform.position.y,swerveSystem.playerCar.transform.position.z);
        }

        if(swerveSystem.playerCar.transform.position.x>4)
        {
            swerveSystem.playerCar.transform.position=new Vector3(4,swerveSystem.playerCar.transform.position.y,swerveSystem.playerCar.transform.position.z);
        }
    }
}
