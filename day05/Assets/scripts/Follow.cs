using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform following;

    float yaw = 0;



    private Vector3 cameraOffset;
    [Range(.01f, 1.0f)]
    public float SmoothFactor = .5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - following.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = following.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        yaw += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(-45, yaw, 0);
    }
}
