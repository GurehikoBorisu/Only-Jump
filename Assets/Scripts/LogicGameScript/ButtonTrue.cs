using UnityEngine;

public class ButtonTrue : MonoBehaviour
{
    public GameObject[] doors;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(doors[0]);
        }
    }
}
