using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Transform target;
    [SerializeField] private float turnSpeedDegrees = 30f;
    [SerializeField] private float moveSpeed = 3f;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        target = FindObjectOfType<FirstPersonController>().transform;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(navMeshAgent == null)
        {
            Debug.LogError($"No {typeof(UnityEngine.AI.NavMeshAgent).Name} on gameObject", this);
        }
    }

    void Update()
    {
        //Vector3 direction = target.position - transform.position;
        //direction.Normalize();
        //Quaternion rotation = Quaternion.LookRotation(-direction);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeedDegrees * Time.deltaTime);
        //transform.position += direction * moveSpeed * Time.deltaTime;


        navMeshAgent.SetDestination(target.position);
    }
}
