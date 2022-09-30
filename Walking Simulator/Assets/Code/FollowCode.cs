using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bottomHalf;
    private Transform bottom;
    Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        bottom = bottomHalf.transform;
        offSet = transform.position - bottom.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = bottom.position + offSet;
    }
    
}

