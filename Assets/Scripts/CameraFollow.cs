using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private int MIN_X;
    [SerializeField ]
    private int MAX_X;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //current position of camera
        tempPos = transform.position;
        //camera position  is equal to players position
        tempPos.x = player.position.x;
        //

        if (tempPos.x > MAX_X)
        {
            tempPos.x = MAX_X;
        }
        else if (tempPos.x < MIN_X)
        {
            tempPos.x = MIN_X;
        }
   
        transform.position = tempPos;

        
        
    }
}
