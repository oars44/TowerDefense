using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node_control : MonoBehaviour
{
    // Start is called before the first frame update

    public bool spawner = false;
    public bool final = false;
    public GameObject enemy;

    public GameObject lastNode;
    public GameObject nextNode;

    private float timer = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner)
        {
            timer += Time.deltaTime;

            if (timer > 4f)
            {
                Spawn();
                timer = 0;
            }
        }
    }

    void Spawn()
    {
        enemy_control recruit = Instantiate(enemy, transform.position, transform.rotation).GetComponent<enemy_control>();
        recruit.previous = gameObject.transform;
        recruit.destination = nextNode.transform;
    }
}
