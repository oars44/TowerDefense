using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    public float speed = 1;
    public float health = 3;
    public float value = 5;
    public TextMesh healthBar;
    public Transform previous;
    public Transform destination;

    private float startHealth;
    private coin_control coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.Find("coin_manager").GetComponent<coin_control>();
        startHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

        if (health < 1)
        {
            coins.coins += value;
            Destroy(gameObject);
        }

        ShowHealth();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform != previous)
        {
            previous = col.transform;
            destination = col.GetComponent<node_control>().nextNode.transform;
        }
    }

    void ShowHealth()
    {
        string display = health.ToString() + " / " + startHealth.ToString();
        healthBar.text = display;
    }

    void OnMouseDown()
    {
        health--;
    }
}
