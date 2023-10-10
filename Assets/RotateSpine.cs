using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RotateSpine : MonoBehaviour
{
    private MultiParentConstraint constraint;

    private void Awake()
    {
        constraint = GetComponent<MultiParentConstraint>();
    }

    private void Update()
    {
        var angle = constraint.data.sourceObjects[0].transform.rotation.eulerAngles.y;
        Debug.Log(angle);
    }
}
