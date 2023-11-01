using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.UI.Image;

public class BombBlockScript : MonoBehaviour
{
    public SurfaceEffector2D surfaceEffector2;
    public PlayerScript player;
    public Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    BoxCollider2D boxCollider;
    //�q�I�u�W�F�N�g�̏��ԂŎ擾�B�ŏ���0�œ�Ԗڂ�1�ƂȂ�B�܂聫�͍ŏ��̎q�I�u�W�F�N�g
    GameObject child;
    // Start is called before the first frame update
    bool stay;
    // �I�u�W�F�N�g�̌��̃X�P�[����ۑ�
    Vector3 originalScale;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
        child = transform.GetChild(0).gameObject;
        child.GetComponent<BoxCollider2D>().enabled = false;
        child.GetComponent<PointEffector2D>().enabled = false;
        transform.localScale= Vector3.zero;
        originalScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();

        transform.DOScale(
    new Vector3(1, 1, 1), // �X�P�[���l
    1f                    // ���o����
);

        // Ray();
        if (!stay)
        {
            transform.position += new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed, 0) * Time.deltaTime;

        }
        // ���C���΂��n�_
        Vector2 rayOrigin = transform.position;

        // ���C�̕����i�������ɔ�΂���j
        Vector2 rayDirection = Vector2.down;

        // ���C�̒���
        float rayLength = 1.0f;

        // ���C�L���X�g�����s
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayLength);

        // ���C�������ɓ��������ꍇ
        if (hit.collider != null)
        {
            Debug.Log("Hit something: " + hit.collider.name);

            // �����œ��������I�u�W�F�N�g�ɑ΂��鏈�����s��
        }
        //���C�̐���
        Ray Ray = new Ray(rayOrigin, rayDirection);
        DrawRay(Ray);
    }

    private void Ray()
    {
        Vector2 origin = transform.position;
        Vector2 upDirection = new Vector2(0, 1);
        Vector2 downDirection = new Vector2(0, -1);
        Vector2 rightDirection = new Vector2(1, 0);
        Vector2 leftDirection = new Vector2(-1, 0);
        //���C�̐���
        Ray upRay = new Ray(origin, upDirection);
        Ray downRay = new Ray(origin, downDirection);
        Ray rightRay = new Ray(origin, rightDirection);
        Ray leftRay = new Ray(origin, leftDirection);
        //���C�ɓ����������̂��������
        RaycastHit upHit;
        RaycastHit downHit;
        RaycastHit rightHit;
        RaycastHit leftHit;

        RaycastHit2D hit = Physics2D.Raycast(origin, upDirection, 10);

        if (hit.collider != gameObject)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
            }
            if (hit.collider.gameObject.CompareTag("BombBlock"))
            {
                Debug.Log("hit Block");
            }

            // Debug.Log("nanikani");
        }

        if (Physics.Raycast(upRay, out upHit, 10))
        {
            if (upHit.collider.CompareTag("Player"))
            {
                Debug.Log("Player");
            }
            if (upHit.collider.name == "Player")
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
        //�v���C���[���]�������
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallUp") || collision.CompareTag("WallDown") || collision.CompareTag("WallRight") || collision.CompareTag("WallLeft"))
        {
            if (!stay)
            {
                boxCollider.isTrigger = false;
                child.GetComponent<PointEffector2D>().enabled = true;
                child.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SurfaceEffector2D>().enabled = true;

                //�Ԃ������ꏊ�̃I�u�W�F�N�g�ɐe�q�t��
                transform.parent = collision.gameObject.transform.parent;
               
                //��Βl���傫���ق��ɐ�����
                if (Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) <= Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y))
                {
                    //��ΒlY�̂ق����傫��������
                    if (transform.position.y - collision.transform.position.y <= 0)
                    {
                        transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - 1.0f);
                    }
                    else
                    {
                        transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1.0f);

                    }
                }
                if (Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) > Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y))
                {
                    //��ΒlX�̂ق����傫��������
                    if (transform.position.x - collision.gameObject.transform.position.x <= 0)
                    {
                        transform.position = new Vector3(collision.gameObject.transform.position.x - 1.0f, collision.gameObject.transform.position.y);

                    }
                    else
                    {
                        transform.position = new Vector3(collision.gameObject.transform.position.x + 1.0f, collision.gameObject.transform.position.y);

                    }
                }
                //else
                //{
                //    transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y);
                //}
                Debug.Log("oyako");
                stay = true;
            }
        }
        if (collision.CompareTag("BombBlock"))
        {
            if (!stay&&collision.gameObject.GetComponent<BombBlockScript>().stay)
            {
                boxCollider.isTrigger = false;
                child.GetComponent<PointEffector2D>().enabled = true;
                child.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SurfaceEffector2D>().enabled = true;

                //�Ԃ������ꏊ�̃I�u�W�F�N�g�ɐe�q�t��
                transform.parent = collision.gameObject.transform.parent;
                //��Βl���傫���ق��ɐ�����
                if (Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) <= Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y))
                {
                    //��ΒlY�̂ق����傫��������
                    if (transform.position.y - collision.transform.position.y <= 0)
                    {
                        transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - 1.0f);
                    }
                    else
                    {
                        transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1.0f);

                    }
                }
                if (Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) > Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y))
                {
                    //��ΒlX�̂ق����傫��������
                    if (transform.position.x - collision.gameObject.transform.position.x <= 0)
                    {
                        transform.position = new Vector3(collision.gameObject.transform.position.x - 1.0f, collision.gameObject.transform.position.y);

                    }
                    else
                    {
                        transform.position = new Vector3(collision.gameObject.transform.position.x + 1.0f, collision.gameObject.transform.position.y);

                    }
                }
                Debug.Log("oyako");
                stay = true;
            }
        }
    }

}
