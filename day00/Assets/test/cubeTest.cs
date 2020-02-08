using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    [Range(1,3)]
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        print("Hello world");
        test();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);
    }

    void test()
    {
        print("testing from this method?");
    }
}
