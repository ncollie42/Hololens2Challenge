using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class club : MonoBehaviour
{
    [SerializeField] private float power = 0;
    Vector3 parent;
    Quaternion og;
    void Start()
    {
        parent = transform.parent.position;
        //GetComponent<Animator>().enabled = false;
        og = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
        
            if (power <= 25)
            {
                power += .5f;
                transform.Rotate(new Vector3(0, Time.deltaTime * 40, 0));
            }
                
            

        }
        //
        //transform.Translate()
        if (Input.GetKeyUp(KeyCode.Space))
        {
            hitBall();
            transform.rotation = og;
        }
    }

    void hitBall()
    {
        transform.parent.GetComponent<ball>().Hit(power);
        power = 0;
        parent = transform.parent.position;
    }
}
