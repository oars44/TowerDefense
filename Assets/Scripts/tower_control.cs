using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_control : MonoBehaviour
{
    public float value = 50;

    private coin_control coins;
    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coins = GameObject.Find("coin_manager").GetComponent<coin_control>();

        mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if ((coins.coins >= value) && (!mesh.enabled))
        {
            coins.coins -= value;
            mesh.enabled = true;
        }
    }
}
