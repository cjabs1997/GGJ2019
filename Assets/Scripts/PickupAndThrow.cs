﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndThrow : MonoBehaviour
{
    public Stack<int> inventory = new Stack<int>();
    public List<GameObject> ammo = new List<GameObject>();
    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inventory.Count > 0)
        {
            Instantiate(ammo[inventory.Pop()], spawner.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Trash"))
        {
            inventory.Push(0);
        }

        if(col.gameObject.name.Contains("Clothes"))
        {
            inventory.Push(1);
        }

        Destroy(col.gameObject);
    }
}