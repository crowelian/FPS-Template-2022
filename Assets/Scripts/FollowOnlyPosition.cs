using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnlyPosition : MonoBehaviour
{

    [SerializeField] Transform follow;

    // Update is called once per frame
    void LateUpdate()
    {
        if (follow != null) gameObject.transform.position = follow.transform.position;
    }
}
