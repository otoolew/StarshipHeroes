using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FlightPhysics))]
public class Aircraft : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;
    public Rigidbody RigidBody
    {
        get { return rigidBody; }
        private set { rigidBody = value; }
    }
    [SerializeField]
    private PilotInput pilotInput;
    public PilotInput PilotInput
    {
        get { return pilotInput; }
        private set { pilotInput = value; }
    }

    [SerializeField]
    private FlightPhysics flightPhysics;
    public FlightPhysics FlightPhysics
    {
        get { return flightPhysics; }
        private set { flightPhysics = value; }
    }

    public Vector3 Velocity { get { return rigidBody.velocity; } }
    public float Throttle { get { return pilotInput.throttle; } }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        pilotInput = GetComponent<PilotInput>();
        flightPhysics = GetComponent<FlightPhysics>();
    }

    private void Update()
    {
        // Pass the input to the physics to move the ship.
        flightPhysics.SetPhysicsInput(new Vector3(pilotInput.strafe, 0.0f, pilotInput.throttle), new Vector3(pilotInput.pitch, pilotInput.yaw, pilotInput.roll));
    }
}
