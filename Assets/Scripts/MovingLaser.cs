using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingLaser : MonoBehaviour
{
    public List<Quaternion> rotate = new List<Quaternion>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Rotate");
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(i >= rotate.Count)
            {
                i = 0;
            }

        }

    }
}
