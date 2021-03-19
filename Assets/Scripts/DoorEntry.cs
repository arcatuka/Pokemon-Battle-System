using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntry : MonoBehaviour
{
    private PlayerMovement theplayer;
    private CameraController Camera;
    void Start()
    {
        theplayer = FindObjectOfType<PlayerMovement>();
        theplayer.transform.position = transform.position;

        Camera = FindObjectOfType<CameraController>();
        Camera.transform.position = new Vector3(transform.position.x,transform.position.y,-3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
