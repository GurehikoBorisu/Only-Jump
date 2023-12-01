using UnityEngine;

public class PicUpObj : MonoBehaviour
{
    private float distance = 3f;
    private float distanceView = 3f;
    public bool isHand;
    public Transform pos;
    private Rigidbody rb;
    public GameObject rayText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
            Debug.Log("Move");
        }
    }

    private void OnMouseEnter()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, distanceView))
        //{
        //    rayText.SetActive(true);
        //}
    }

    private void OnMouseExit()
    {
        //if (distanceView < 4)
        //{
        //    rayText.SetActive(false);
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DeathBlock")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (rb.isKinematic == true)
        {
            gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.P))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                //rayText.SetActive(false);
                rb.AddForce(Camera.main.transform.forward * 500);
                Debug.Log("Drop");
            }
        }
    }
}
