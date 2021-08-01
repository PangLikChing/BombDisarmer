using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCamera;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        transform.position = new Vector3(0, 2.5f, 0);
        transform.localEulerAngles = new Vector3(15, 0, 0);
        offset = new Vector3(0, 2.0f, 0);
    }
    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetMouseButton(1))
        {
            transform.localEulerAngles = player.transform.localEulerAngles + new Vector3(15, 0, 0);
        }
    }
}
