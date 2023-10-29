using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float gravityForce;
    [SerializeField] private PlayerScript player;
    public PointEffector2D pointEffector;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //gravityForce = player.gravityForce;
        pointEffector.forceMagnitude = player.gravityForce;
    }
}
