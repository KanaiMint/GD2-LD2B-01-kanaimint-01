using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BombBlockScript : MonoBehaviour
{
    public SurfaceEffector2D surfaceEffector2;
    public PlayerScript player;
    public Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Ray();       
    }

    private void Ray()
    {
        Vector2 origin = transform.position;
        Vector2 upDirection = new Vector2(0, 1);
        Vector2 downDirection = new Vector2(0, -1);
        Vector2 rightDirection = new Vector2(1, 0);
        Vector2 leftDirection = new Vector2(-1, 0);
        //ÉåÉCÇÃê∂ê¨
        Ray upRay = new Ray(origin, upDirection);
        Ray downRay = new Ray(origin, downDirection);
        Ray rightRay = new Ray(origin, rightDirection);
        Ray leftRay = new Ray(origin, leftDirection);
        //ÉåÉCÇ…ìñÇΩÇ¡ÇΩÇ‡ÇÃÇì¸ÇÍÇÈÇ‡ÇÃ
        RaycastHit upHit;
        RaycastHit downHit;
        RaycastHit rightHit;
        RaycastHit leftHit;

        RaycastHit2D hit=Physics2D.Raycast(origin, upDirection, 10);

        if (hit.collider != gameObject)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
            } if (hit.collider.gameObject.CompareTag("BombBlock"))
            {
                Debug.Log("hit Block");
            }

           // Debug.Log("nanikani");
        }

        if (Physics.Raycast(upRay, out upHit,10))
        {
            if (upHit.collider.CompareTag("Player"))
            {
                Debug.Log("Player");
            } if (upHit.collider.name=="Player")
            {
                Debug.Log("Player");
            }
            if (upHit.collider.tag == "Player")
            {
                Debug.Log("Player");
            }
            if (upHit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("Player");
            }
            if (upHit.collider)
            {
                Debug.Log("awdadad");
            }
        }
       

        DrawRay(upRay);
        DrawRay(downRay);
        DrawRay(rightRay);
        DrawRay(leftRay);
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
    private void DrawRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
    }
    //private void DrawRay(Ray ray,bool isCollide)
    //{

    //    Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
    //}
}
