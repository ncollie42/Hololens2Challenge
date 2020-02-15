using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool active = false;
    [SerializeField] int moveMult = 20;
    [SerializeField] int jumpMult = 100;
    Vector3 moveDir;
    float halfHight;
    int maxVelocity = 30;
    bool canJump = false;
    Rigidbody rigids;
    // Start is called before the first frame update
    void Start()
    {
        halfHight = transform.lossyScale.y / 2;
        rigids = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            getMovementVector();
        }
    }

    void getMovementVector()
    {
        moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            canJump = true;
        }

    }

    bool isGrounded()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, 1);
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
        //.1f buffer
        if (hit.distance <= (halfHight + .1f))
            return true;
           
        return false;
    }

    void move()
    {
        GetComponent<Rigidbody>().AddForce(moveDir * moveMult);
        limitVelocity();
        
    }

    void jump()
    {
        if (canJump)
        {
            
            rigids.AddForce(Vector3.up * jumpMult);
            limitVelocity();
            canJump = false;
        }
       
    }

    void limitVelocity()
    {
        int velocity = maxVelocity;
        Vector3 tmp = rigids.velocity;
        if (Mathf.Abs(rigids.velocity.x) > maxVelocity)
        {
            if (rigids.velocity.x < 0)
                velocity = maxVelocity * -1;
            tmp.x = velocity;
        }
            
        if (Mathf.Abs(rigids.velocity.y) > maxVelocity)
        {
            if (rigids.velocity.y < 0)
                velocity = maxVelocity * -1;
            tmp.y = velocity;
        }
        if (Mathf.Abs(rigids.velocity.z) > maxVelocity)
        {
            if (rigids.velocity.z < 0)
                velocity = maxVelocity * -1;
            tmp.z = velocity;
        }
        rigids.velocity = tmp;
    }

    private void FixedUpdate()
    {
        if (active)
        {
            move();
            jump();
        }
    }
}
