using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, -2.0f, 0.0f, Space.Self);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, 2.0f, 0.0f, Space.Self);
            }
        }

    }

    void hit()
    {

    }
}
