using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public LayerMask groundLayer;
    private LayerMask groundInt;

    // Start is called before the first frame update
    void Start()
    {
        groundInt = (int)Mathf.Log(groundLayer, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D ground)
    {
        Debug.Log("yes");
        if (ground.gameObject.layer == groundInt)
        {
            Debug.Log("hi");
            
        }
    }
} 
