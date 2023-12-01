using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRaayDoorsOn : MonoBehaviour
{
    private float distance = 3f;
    public GameObject doors;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance) && tag == "DoorsOn")
        {
            Destroy(doors);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
