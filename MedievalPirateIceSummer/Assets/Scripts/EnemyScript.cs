//https://gamedev.stackexchange.com/questions/162327/how-to-implement-the-seek-steering-behavior-in-unity3d

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float MaxVel = 4;
    public float MaxFor = 20;
    public float mass = 15;

    private Vector3 Vel;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Vel = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        var dVelocity = target.transform.position - transform.position;
        dVelocity = dVelocity.normalized * MaxVel;

        var steer = dVelocity - Vel;
        steer = Vector3.ClampMagnitude(steer, MaxFor);
        steer /= mass;

        Vel = Vector3.ClampMagnitude(Vel + steer, MaxVel);
        transform.position += Vel * Time.deltaTime;
        transform.forward = Vel.normalized; 
    }
}
