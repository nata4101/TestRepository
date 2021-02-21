using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    public GameObject player_shadow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            player.SetActive(true);
            player_shadow.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            player.SetActive(false);
            player_shadow.SetActive(true);
            player_shadow.transform.position = player.transform.position;
            player_shadow.transform.rotation = player.transform.rotation;
        }
    }
}
