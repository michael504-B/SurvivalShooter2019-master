using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{

    [SerializeField]
    Transform FollowTarget;

    [SerializeField]
    bool x = false;

    [SerializeField]
    bool y = false;

    [SerializeField]
    bool z = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 NewPos = FollowTarget.position;

        if (!x)
        {
            NewPos.x = transform.position.x;
        }

        if (!y)
        {
            NewPos.y = transform.position.y;
        }

        if (!z)
        {
            NewPos.z = transform.position.z;
        }

        transform.position = NewPos;
    }
}
