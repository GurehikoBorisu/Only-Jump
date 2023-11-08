using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _targetTime;

    [SerializeField]
    private float sphereRadius;

    private int _targetWaypointIndex;

    private Vector3 _previousWaypoint;
    private Vector3 _targetWaypoint;

    private bool isMoving = true;

    private float _timeToWaypoint;
    private float _elapsedTime;

    [SerializeField]
    private GameObject _player;

    public LayerMask layer;


    void Start()
    {
        TargetNextWaypoint();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
    void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, sphereRadius, layer))
        {
            _player.transform.SetParent(transform);
        }
        if (isMoving)
        {
            _elapsedTime += Time.deltaTime;

            float elapsedPercentage = _elapsedTime / _timeToWaypoint;
            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
            transform.position = Vector3.Lerp(_previousWaypoint, _targetWaypoint, elapsedPercentage);

            if (elapsedPercentage >= 1)
            {
                isMoving = false;
                StartCoroutine("TargetNextWaypoint");
            }
        }
    }

    IEnumerator TargetNextWaypoint()
    {
        yield return new WaitForSeconds(1);
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint, _targetWaypoint);
        _timeToWaypoint = _targetTime;
        isMoving = true;
    }
    
    private void TargetNextWaypointo()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint, _targetWaypoint);
        _timeToWaypoint = _targetTime;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.transform.SetParent(null); 
        }
    }
}
