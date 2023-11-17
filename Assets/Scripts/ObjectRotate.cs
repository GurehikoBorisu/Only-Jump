using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    public List<Quaternion> rotations = new List<Quaternion>();
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
            while (i < rotations.Count) 
            {
                startRotation = transform.rotation;
                targetRotation = rotations[i];
                startTime = Time.time;
                while (Time.time - startTime < duration)
                {
                    float t = (Time.time - startTime) / duration;
                    transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                    yield return null;
                }
                transform.rotation = targetRotation;
                i++;
            }
            i = 0;
            yield return new WaitForSeconds(delay);
        }
    }
}
