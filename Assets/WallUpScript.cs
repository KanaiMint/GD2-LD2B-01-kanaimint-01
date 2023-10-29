using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WallUpScript : MonoBehaviour
{
    public bool onPlayer;
    public float moveSpeed;
    private string targetTag = "WallUp";
    GameObject[] taggedObjects;
    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトのスクリプトを取得
        // wallScript = transform.parent.GetComponent<WallScript>();
        // 指定したタグが付いているすべてのオブジェクトを取得
        taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPlayer)
        {
            transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
            // 各オブジェクトに対して処理を実行
            foreach (GameObject obj in taggedObjects)
            {
                // オブジェクトからスプライトレンダラーを取得
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                // スプライトレンダラーが存在し、カラーを変更できる場合
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.white;
                }
            }
        }
        else if (onPlayer)
        {
            transform.position += new Vector3(0, moveSpeed * 1.5f, 0) * Time.deltaTime;
            transform.position=new(transform.position.x, Mathf.Clamp(transform.position.y,-8.0f,0),transform.position.z);
            // 各オブジェクトに対して処理を実行
            foreach (GameObject obj in taggedObjects)
            {
                // オブジェクトからスプライトレンダラーを取得
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                // スプライトレンダラーが存在し、カラーを変更できる場合
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.green;
                }
            }

        }

        // すべてのオブジェクトを調べて条件を確認
        foreach (WallScript script in FindObjectsOfType<WallScript>())
        {
            if (script.onPlayer && script.gameObject.CompareTag("WallUp"))
            {
                // 1つでもtrueがあればフラグをfalseに設定
                onPlayer = true;
                break; // ループを抜けてもう続行の必要がない
            }
            else
            {
                onPlayer = false;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log("player");
    //        onPlayer = true;
    //    }
    //}
}
