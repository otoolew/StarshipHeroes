﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StarshipNavigation : MonoBehaviour
{
    #region Fields / Properties      
    [SerializeField]
    private Rigidbody rigidBody;
    public Rigidbody RigidBody
    {
        get { return rigidBody; }
        private set { rigidBody = value; }
    }
    [SerializeField]
    private NavMeshAgent navAgent;
    public NavMeshAgent NavAgent
    {
        get { return navAgent; }
        private set { navAgent = value; }
    }
    public float rotationSpeed;
    public float RotationSpeed
    {
        get { return rotationSpeed; }
        private set { rotationSpeed = value; }
    }
    [SerializeField]
    private float maxVelocity;
    public float MaxVelocity
    {
        get { return maxVelocity; }
        private set { maxVelocity = value; }
    }
    public float CurrentVelocity
    {
        get { return rigidBody.velocity.magnitude; }
    }

    [SerializeField]
    private Vector3 previousDestination;
    public Vector3 PreviousDestination
    {
        get { return previousDestination; }
        private set { previousDestination = value; }
    }
    [SerializeField]
    private Vector3 currentDestination;
    public Vector3 CurrentDestination
    {
        get { return currentDestination; }
        private set { currentDestination = value; }
    }

    public float stopDistance;
    public float StopDistance
    {
        get { return stopDistance; }
        set { stopDistance = value; }
    }

    public float DistanceToDestination
    {
        get
        {
            return Vector2.Distance(currentDestination, transform.position);
        }
    }

    private Quaternion lookRotation;
    //public Vector3 EulerAngleVelocity { get; set; }
#endregion
    // Use this for initialization
    void Start()
    {
        GetComponent<Starship>().OnStarshipDeath.AddListener(DeactivateNavigation);
        //navStack = new Stack<Vector3>();
        rigidBody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.enabled = true;

        maxVelocity = GetComponentInChildren<EngineComponent>().EnginePower;
        rotationSpeed = GetComponentInChildren<HullComponent>().RotationSpeed;

        //EulerAngleVelocity = new Vector3(0, GetComponentInChildren<HullComponent>().RotationSpeed, 0);
        navAgent.speed = maxVelocity;
        navAgent.angularSpeed = rotationSpeed;
        navAgent.acceleration = maxVelocity / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Vector2.Distance(transform.position, navAgent.destination)) < navAgent.stoppingDistance))
        {
            Vector3 directionToTarget = (currentDestination - transform.position).normalized;
            if (directionToTarget != Vector3.zero)
            {
                lookRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * GetComponentInChildren<HullComponent>().RotationSpeed);
            }
            //rigidBody.AddForce((currentDestination - transform.position));
            // Slow towards
            //rigidBody.velocity = (currentDestination - transform.position);
        }
    }
    void FixedUpdate()
    {
        //PhysicsMove();
    }
    public void GoToPosition(Vector3 vector)
    {
        if(navAgent.isActiveAndEnabled)
            navAgent.destination = vector;
    }
    public void SetStoppingDistance(float distance)
    {
        if (navAgent.isActiveAndEnabled)
            navAgent.stoppingDistance = distance;
    }
    public void StopAgent()
    {
        navAgent.SetDestination(transform.position);
    }
    private void DeactivateNavigation()
    {
        StopAgent();
        navAgent.enabled = false;
    }
    public void PhysicsMove()
    {     
        Vector3 directionToTarget = (currentDestination - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            lookRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * GetComponentInChildren<HullComponent>().RotationSpeed);
        }

        if (((Vector2.Distance(transform.position, currentDestination)) > stopDistance))
        {
            rigidBody.AddForce((currentDestination - transform.position));
            // Slow towards
            //rigidBody.velocity = (currentDestination - transform.position);
        }

        //if(Vector3.Angle(transform.forward, directionToTarget) == 0)
        //{
        //    if (((Vector2.Distance(transform.position, currentDestination)) > stopDistance))
        //    {
        //        rigidBody.AddForce((currentDestination - transform.position));
        //        // Slow towards
        //        //rigidBody.velocity = (currentDestination - transform.position);
        //    }
        //}

        if (rigidBody.velocity.magnitude > GetComponentInChildren<EngineComponent>().EnginePower)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, GetComponentInChildren<EngineComponent>().EnginePower);
        }
        
    }
}
