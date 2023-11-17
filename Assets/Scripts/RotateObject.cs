using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public List<Quaternion> rotation = new List<Quaternion>();
    public float delay;
    public float duration;
    void Start()
    {
        StartCoroutine("Rotate");
    }
    IEnumerator Rotate()
    {
        Quaternion startRotation;
        Quaternion targetRotation;
        float startTime;
        int i = 0;
        while (true)
        {
            startRotation = transform.rotation;
            targetRotation = rotation[i];
            startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                yield return null;
            }
            transform.rotation = targetRotation;
            i++;
            if (i >= rotation.Count)
            {
                i = 0;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
