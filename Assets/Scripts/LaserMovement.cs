using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public float delay;
    public float duration;
    void Start()
    {
        StartCoroutine("Moving");
    }
    IEnumerator Moving()
    {
        Vector3 startPositon;
        Vector3 targetPosition;
        float startTime;
        int i = 0;
        while (true)
        {
            while (i< positions.Count)
            {
                startPositon = transform.position;
                targetPosition = positions[i];
                startTime = Time.time;
                while (Time.time - startTime < duration)
                {
                    float t = (Time.time - startTime) / duration;
                    transform.position = Vector3.Slerp(startPositon, targetPosition, t);
                    yield return null;
                }
                transform.position = targetPosition;
                i++;
            }
            i = 0;
            yield return new WaitForSeconds(delay);
        }
    }
}
