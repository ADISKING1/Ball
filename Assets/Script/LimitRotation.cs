using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRotation : MonoBehaviour
{
    [SerializeField]
    private float limitAngle = 25;
    [SerializeField]
    private float turnBackSpeed = 1f;

    private Quaternion defaultAngle;

    public float LimitAngle { get => limitAngle; set => limitAngle = value; }
    public float TurnBackSpeed { get => turnBackSpeed; set => turnBackSpeed = value; }

    private void Start()
    {
        defaultAngle = transform.rotation;
    }

    void FixedUpdate()
    {
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, -limitAngle, limitAngle);
        transform.eulerAngles = euler;
        transform.rotation = Quaternion.Slerp(transform.rotation, defaultAngle, turnBackSpeed);
    }
}
