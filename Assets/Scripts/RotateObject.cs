using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public List<Quaternion> rotate = new List<Quaternion>();
    void Start()
    {
        StartCoroutine("Rotate");
    }
    IEnumerator Rotate()
    {
        Quaternion startRotation;
        Quaternion targetRotation;
        float startTime;
        float duration = 3;
        int i = 0;
        while (true)
        {
            startRotation = transform.rotation;
            targetRotation = rotate[i];
            startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                yield return null;
            }
            transform.rotation = targetRotation;
            i++;
            if (i >= rotate.Count)
            {
                i = 0;
            }
        }
    }
}
