using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform target;
    [SerializeField] private float turnSpeedDegrees = 30f;
    [SerializeField] private float moveSpeed = 3f;

    void Start()
    {
        target = FindObjectOfType<FirstPersonController>().transform;
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(-direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeedDegrees * Time.deltaTime);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
