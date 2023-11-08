using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjKill : MonoBehaviour
{
    [SerializeField] private int sceneCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneCount);
        }
    }
}
