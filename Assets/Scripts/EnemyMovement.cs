using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 _direction = target.position - transform.position;
        transform.Translate(_direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {

        if(wavePointIndex >= WayPoints.points.Length -1 && target != null)
        {
            Destroy(gameObject);
            return;
        }


        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

}
