using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionScript : MonoBehaviour
{
    [SerializeField] public Vector2 shotDirection;
    [SerializeField] Vector2 shot2Direction;
    [SerializeField] Vector2 collsionpos;
    [SerializeField] float maxNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotDirection.x = transform.position.x - collsionpos.x;
        shotDirection.y = transform.position.y - collsionpos.y;
        shotDirection.Normalize();
        shot2Direction = shotDirection;
        if (shotDirection.x > maxNum)
        {
            shotDirection.x = 1;
        }else
        if (shotDirection.x <= -maxNum)
        {
            shotDirection.x = -1;
        }
        else
        {
            shotDirection.x = 0;
        }
        if (shotDirection.y > maxNum)
        {
            shotDirection.y = 1;
        }else
        if (shotDirection.y <= -maxNum)
        {
            shotDirection.y = -1;
        }
        else
        {
            shotDirection.y = 0;
        }
        Ray();
    }
    private void Ray()
    {
        Vector2 origin = transform.position;

        //ƒŒƒC‚Ì¶¬
        Ray upRay = new Ray(origin, shotDirection);

        DrawRay(upRay);

    }
    private void DrawRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            collsionpos = collision.transform.position;
        }
    }
}
