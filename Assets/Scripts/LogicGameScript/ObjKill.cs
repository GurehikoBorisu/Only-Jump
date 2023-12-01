using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjKill : MonoBehaviour
{
    public Vector3 boxSize;
    public LayerMask layer;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    private void Update()
    {
        if (Physics.CheckBox(transform.position, boxSize, new Quaternion(0, 0, 0, 0), layer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
