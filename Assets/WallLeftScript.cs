using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLeftScript : MonoBehaviour
{
    public bool onPlayer;
    public float moveSpeed;
    private string targetTag = "WallLeft";
    GameObject[] taggedObjects;
    // Start is called before the first frame update
    void Start()
    {
        // 指定したタグが付いているすべてのオブジェクトを取得
        taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPlayer)
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
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
            transform.position=new( Mathf.Clamp(transform.position.x, 0,8.0f),transform.position.y, transform.position.z);
            transform.position += new Vector3(-moveSpeed * 1.5f, 0, 0) * Time.deltaTime;
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
            if (script.onPlayer && script.gameObject.CompareTag("WallLeft"))
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
}
