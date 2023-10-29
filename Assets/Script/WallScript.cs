using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public SurfaceEffector2D surfaceEffector2;
    public PlayerScript player;
    public float moveWallSpeed;
    public WallUpScript wallUpScript;
    public bool onPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        //wallUpScript= transform.parent.GetComponent<WallUpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (player.directionRotate)
        {
            surfaceEffector2.speed = player.moveSpeed;
        }
        if (!player.directionRotate)
        {
            surfaceEffector2.speed = -player.moveSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayer = false;
        }
    }
}
