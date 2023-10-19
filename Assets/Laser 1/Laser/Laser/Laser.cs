using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform point;
    public int damage = 40;
    public float distance;
    public LineRenderer lineRenderer;

    // public GameObject impactEffect;

    public ParticleSystem impactEffect;

    public Light impactLight;

    public Vector3 linePos;

    private void Start()
    {
        lineRenderer.transform.position = linePos;
        lineRenderer.useWorldSpace = true;
    }
    // Update is called once per frame
    void Update()
    {
        Laserstrahl();
    }

    void Laserstrahl()
    {
        RaycastHit hitInfo;
        lineRenderer.enabled = true;
        if (Physics.Raycast(point.position, point.right, out hitInfo, distance))
        {
            Vector3 hitPoint = hitInfo.point;

            Debug.DrawRay(point.position, point.right * hitInfo.distance, Color.red);

            impactLight.enabled = true;
            impactEffect.Play();

            lineRenderer.SetPosition(0, point.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            Vector3 dir = point.position - hitPoint.normalized;

            impactEffect.transform.position = hitInfo.point + dir.normalized * .5f;

            impactEffect.transform.rotation  = Quaternion.LookRotation(dir);
        }
        else
        {
            Debug.DrawRay(point.position, point.right * distance, Color.green);

            lineRenderer.SetPosition(0, point.position);
            lineRenderer.SetPosition(1, point.position + point.right * 100);

            impactLight.enabled = false;

            impactEffect.Stop();
        }

    }
}
