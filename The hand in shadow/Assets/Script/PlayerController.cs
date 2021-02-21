using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 mouse_pos;

    // Update is called once per frame
    void Update()
    {
        float speed = 1.0f;

        float mouse_speed = 0.3f;

        Transform transform = this.GetComponent<Transform>();

        Vector3 now_mouse_pos = Input.mousePosition;

        transform.Rotate(new Vector3(0.0f, (now_mouse_pos.x - mouse_pos.x) * mouse_speed, 0.0f));
        mouse_pos = now_mouse_pos;

        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            force += transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            force -= transform.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force -= transform.right;
        }

        
        force = Vector3.Normalize(force);

        force *= speed;

        rb.AddForce(force);
    }
}
