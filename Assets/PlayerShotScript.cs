using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotScript : MonoBehaviour
{
    public GameObject bomBlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ÉuÉçÉbÉNÇÃê∂ê¨
            GameObject bombblock;
            bombblock = Instantiate(bomBlock);
            bombblock.GetComponent<BombBlockScript>().moveDirection = transform.GetComponent<PlayerDirectionScript>().shotDirection;
            bombblock.transform.position = transform.position;
            bombblock.transform.parent = transform.parent;

        }
    }

}
