using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public List<Vector3> position = new List<Vector3>();
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
            startPositon = transform.position;
            targetPosition = position[i];
            startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.position = Vector3.Slerp(startPositon, targetPosition, t);
                yield return null;
            }
            transform.position = targetPosition;
            i++;
            if (i >= position.Count)
            {
                i = 0;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
