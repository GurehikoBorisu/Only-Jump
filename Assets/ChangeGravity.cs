using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Измените на нужную вам кнопку
        {
            if (!isRotating)
            {
                isRotating = true;
                StartCoroutine(ChangeGravityAndRotateObject());
            }
        }
    }

    private System.Collections.IEnumerator ChangeGravityAndRotateObject()
    {
        // Изменение гравитации
        Physics.gravity = -Physics.gravity;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 180f);

        float startTime = Time.time;
        float duration = 1.0f; // Измените на нужное время поворота

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}
