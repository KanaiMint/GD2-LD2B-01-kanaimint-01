using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public Vector2 gravityDirection;
    [SerializeField] public float gravityForce;
    [SerializeField] public bool directionRotate;
    public Rigidbody2D rb;
    private bool isCollider;
    
    [SerializeField] enum State { up, down, right, left };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionRotate = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionRotate = false;
        }
        if (!isCollider)
        {
            rb.velocity = Vector2.zero;
           // transform.position += new Vector3(gravityDirection.x, gravityDirection.y, 0) * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallUp"))
        {
            gravityDirection = new Vector2(0, 1);
        }
        if (collision.CompareTag("WallDown"))
        {
            gravityDirection = new Vector2(0, -1);
        }
        if (collision.CompareTag("WallRight"))
        {
            gravityDirection = new Vector2(1, 0);
        }
        if (collision.CompareTag("WallLeft"))
        {
            gravityDirection = new Vector2(-1, 0);
        }
        if (collision != null)
        {
            isCollider = true;
        }
        if (collision.CompareTag("BombBlock"))
        {
            //float directionX = transform.position.x - collision.transform.position.x;
            //float directionY = transform.position.y - collision.transform.position.y;
            //if ((int)directionX <0)
            //{

            //}
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollider = false;
    }
}
