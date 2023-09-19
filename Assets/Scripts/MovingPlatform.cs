using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Vector3> position = new List<Vector3>();
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Moving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Moving()
    {
        Vector3 startPositon;
        Vector3 targetPosition;
        float startTime;
        float duration;
        int i = 0;
        while (true)
        {
            startPositon = transform.position;
            targetPosition = position[i];
            startTime = Time.time;
            duration = 5;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.position = Vector3.Slerp(startPositon, targetPosition, t);
                yield return null;
            }
            transform.position = targetPosition;
            i++;
            if(i>=position.Count)
            {
                i = 0;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }

    }
    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
