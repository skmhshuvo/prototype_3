using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public Vector3 startPos;
    public float repWidth;
    void Start()
    {
        startPos = transform.position;
        repWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repWidth)
        {
            transform.position = startPos;
        }
    }
}
