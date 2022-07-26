using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMove : MonoBehaviour
{
    SwerveSystem swerveSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    private void Awake()
    {
        swerveSystem = GetComponent<SwerveSystem>();
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveSystem.MoveFactorX;
        swerveSystem.playerCar.transform.Translate(x: 0, y: 0, z: -swerveAmount);
    }
}
