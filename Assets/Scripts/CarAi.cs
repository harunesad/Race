using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarAi : MonoBehaviour
{
    [SerializeField] Transform targetPositionTranform;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float xSpeed = 0;
    [SerializeField] float zSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();    
    }
    void WayPoint(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            waypoints.Remove(waypoints[0]);
            targetPositionTranform = null;
            Destroy(other.gameObject);
            if (targetPositionTranform == null && waypoints.Count > 0)
            {
                targetPositionTranform = waypoints[0];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WayPoint(other);
    }
    private void Movement()
    {
        if (waypoints.Count > 0)
        {
            transform.Translate(xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
            if (waypoints[0].position.x > transform.position.x)
            {
                xSpeed = 10f;
            }
            else if (waypoints[0].position.x < transform.position.x)
            {
                xSpeed = -10f;
            }
            float distance = Mathf.Abs(waypoints[0].position.x - transform.position.x);
            if (distance < 0.1f)
            {
                xSpeed = 0;
            }
        }
        
    }
}
