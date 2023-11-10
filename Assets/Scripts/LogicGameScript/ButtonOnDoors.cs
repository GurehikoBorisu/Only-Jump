using UnityEngine;

public class ButtonOnDoors : MonoBehaviour
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
