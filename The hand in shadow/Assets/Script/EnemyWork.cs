using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWork : MonoBehaviour
{
    public int go_points;

    public Transform player_position;

    public GameObject sight;

    EnemySight script;

    Vector3[] way_points = {
       new Vector3(-2.5f,0.5f,-7.0f),
       new Vector3(2.5f,0.5f,-7.0f),
       new Vector3(2.5f,0.5f,7.0f),
       new Vector3(-2.5f,0.5f,7.0f)
    };
    int way_count = 4;

    float flame = 0.0f;

    float enemy_speed = 0.001f;

    float enemy_serch_speed = 0.9f;

    Vector3 go_front;

    Vector3 look_front;



    // Start is called before the first frame update
    void Start()
    {
        script = sight.GetComponent<EnemySight>();

    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = this.GetComponent<Transform>();

        Rigidbody rigidbody = this.GetComponent<Rigidbody>();

        if (script.IsSight)
        {
            go_front = player_position.position - transform.position;
            look_front = Vector3.Normalize(go_front);
            go_front = look_front;

            rigidbody.AddForce(go_front * enemy_serch_speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, way_points[go_points], enemy_speed);

            go_front = way_points[go_points] - transform.position;

            look_front = Quaternion.Euler(new Vector3(0, (Mathf.Sin(flame) * 15.0f), 0)) * go_front;


        }

        transform.forward = look_front;

        flame += 0.003f;

        if (Vector3.Distance(way_points[go_points], transform.position) < 1.0f)
        {
            go_points++;
            go_points %= way_count;
        }
  
    }
}
