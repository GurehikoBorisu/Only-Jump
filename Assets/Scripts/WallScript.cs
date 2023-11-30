using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
/*        if (player.isDestroyWall)
        {
            Destroy(gameObject);
        }*/
    }
}
