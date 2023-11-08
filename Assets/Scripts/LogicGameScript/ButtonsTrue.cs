using UnityEngine;

public class ButtonsTrue : MonoBehaviour
{
    private float distance = 3f;

    public GameObject door;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
           Destroy(door);
        }
    }
}
