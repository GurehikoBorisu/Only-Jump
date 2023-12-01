using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    int currentLevel;
    int levelsComplete;

    public Vector3 boxSize;
    public LayerMask layer;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        levelsComplete = PlayerPrefs.GetInt("Level");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 2, 0), boxSize);
    }

    private void Update()
    {
        if (Physics.CheckBox(transform.position + new Vector3(0, 2, 0), boxSize, new Quaternion(0, 0, 0, 0), layer))
        {
            if (levelsComplete < currentLevel+1 && levelsComplete != 5)
            {
                PlayerPrefs.SetInt("Level", currentLevel + 1);
            }
        }
    }
}
