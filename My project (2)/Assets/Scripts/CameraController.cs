using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    //public Transform player;

    //public bool X, Y, Z;

    //public float XOffset, YOffset, ZOffset;
    public GameObject player;
    void Update()
    {
        //Vector3 targetPos = player.position;
        // Vector3 currentPos = transform.position;
        transform.position = new Vector3(player.transform.position.x, 0, -10);
        /*
        transform.position = new Vector3(
                X ? targetPos.x + XOffset : currentPos.x,
                Y ? Mathf.Min(currentPos.y, targetPos.y + YOffset) : currentPos.y,
                Z ? targetPos.z + ZOffset : currentPos.z);*/
    }

}