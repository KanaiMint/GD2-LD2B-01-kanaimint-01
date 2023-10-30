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
        // �w�肵���^�O���t���Ă��邷�ׂẴI�u�W�F�N�g���擾
        taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPlayer)
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            // �e�I�u�W�F�N�g�ɑ΂��ď��������s
            foreach (GameObject obj in taggedObjects)
            {
                // �I�u�W�F�N�g����X�v���C�g�����_���[���擾
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                // �X�v���C�g�����_���[�����݂��A�J���[��ύX�ł���ꍇ
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
            // �e�I�u�W�F�N�g�ɑ΂��ď��������s
            foreach (GameObject obj in taggedObjects)
            {
                // �I�u�W�F�N�g����X�v���C�g�����_���[���擾
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                // �X�v���C�g�����_���[�����݂��A�J���[��ύX�ł���ꍇ
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.green;
                }
            }
        }
        // ���ׂẴI�u�W�F�N�g�𒲂ׂď������m�F
        foreach (WallScript script in FindObjectsOfType<WallScript>())
        {
            if (script.onPlayer && script.gameObject.CompareTag("WallLeft"))
            {
                // 1�ł�true������΃t���O��false�ɐݒ�
                onPlayer = true;
                break; // ���[�v�𔲂��Ă������s�̕K�v���Ȃ�
            }
            else
            {
                onPlayer = false;
            }
        }
    }
}
