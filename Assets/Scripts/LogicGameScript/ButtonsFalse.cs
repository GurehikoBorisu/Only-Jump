using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFalse : MonoBehaviour
{
    private float distance = 3f;
    public int sceneCount;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            SceneManager.LoadScene(sceneCount);
        }
    }
}
