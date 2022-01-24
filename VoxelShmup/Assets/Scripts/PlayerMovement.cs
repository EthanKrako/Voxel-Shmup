using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 30;
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(horizontal, 0, vertical).normalized * speed;
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0,180,horizontal * 20), Time.deltaTime * 5);
    }
}
