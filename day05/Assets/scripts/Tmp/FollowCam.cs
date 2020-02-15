using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform ball;

   
    private Vector3 cameraOffset;
    [Range(.01f, 1.0f)]
    public float SmoothFactor = .5f;
    public float rotationSpeed = 50.0f;

    public bool rotate = true;
    public bool lookat = true;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - ball.position;
    }

    private void LateUpdate()
    {
        if (rotate)
        {
            Debug.Log(Input.GetAxis("Mouse X"));
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = camTurnAngle * cameraOffset;
            Debug.Log("turn angle" + camTurnAngle);
        }

        Vector3 newPos = ball.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (lookat)
            transform.LookAt(ball);
    }
}
