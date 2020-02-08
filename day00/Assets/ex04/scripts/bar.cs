using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] KeyCode p1UP;
    [SerializeField] KeyCode p1DOWN;
    [SerializeField] int speed = 35;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        
        if (Input.GetKey(p1UP) && (transform.position.z < 7.2))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(p1DOWN) && (transform.position.z > -7.2))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
