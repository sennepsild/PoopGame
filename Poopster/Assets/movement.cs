using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float Speed;
    Rigidbody rb;
    CapsuleCollider coll;
    public LayerMask mask;
    bool grounded = false;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 InputDirection = new Vector3(-Input.GetAxis("Horizontal"),0, -Input.GetAxis("Vertical"));
        InputDirection = Vector3.Normalize(InputDirection);
        InputDirection *= Speed;
        InputDirection.y = rb.velocity.y;
        rb.velocity =  InputDirection;

        Ray ray = new Ray(new Vector3(coll.bounds.center.x, coll.bounds.min.y+0.015f, coll.bounds.center.z), Vector3.down);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, 0.2f, mask))
        {
            
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += Vector3.up * jumpHeight;
        }
        if(transform.position.y < -3)
        {
            transform.position = new Vector3(0, 2, 0);
        }

    }
}
