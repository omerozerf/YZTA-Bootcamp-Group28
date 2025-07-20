using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 5f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        RotateTowardsTarget();

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;

        if (direction.magnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {

            Wavespawner.enemiesAlive--;
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
