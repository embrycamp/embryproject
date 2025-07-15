using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed = 75f;
    public float jumpforce;
    public Rigidbody rig;
    public int health;

    public int coinCount;

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 rotation = Vector3.up * x;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;
        dir.y = rig.velocity.y;
        rig.velocity = dir;
        
    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.5f))
        {
            rig.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //input for movement
        Move();

        //input for jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }

    }
}