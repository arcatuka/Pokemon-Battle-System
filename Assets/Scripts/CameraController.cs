using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarger;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool CamExist;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        if(!CamExist)
        {
            CamExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(followTarger.transform.position.x, followTarger.transform.position.y,-3);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed* Time.deltaTime);
    }
}
