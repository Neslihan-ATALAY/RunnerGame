using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 cameraPosition = new Vector3
            (transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, 10 * Time.deltaTime);
    }
}
