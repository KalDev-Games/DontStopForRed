using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingEngine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected string nameOfCar;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected AnimationCurve speedingCurve;
    [SerializeField]
    protected AnimationCurve brakingCurve;
    [SerializeField]
    protected float maxSpeed;

    public Rigidbody Rb { get => rb; set => rb = value; }

    public DrivingEngine(AnimationCurve speed, AnimationCurve brake, string name, float maxSpeed)
    {
        speedingCurve = speed;
        brakingCurve = brake;
        nameOfCar = name;
        this.maxSpeed = maxSpeed;

        
    }

    private void Update()
    {
        if (rb.velocity.z < .01f)
        {
            Debug.Log("Too slow");
        }
    }

    public void Accelerate(float accelerationTime)
    {
        if (rb.velocity.z < maxSpeed)
        {
            rb.AddRelativeForce(Vector3.forward * speedingCurve.Evaluate(accelerationTime) * 10);
        }

        
    }

    public void Brake(float brakingTime)
    {
        if (rb.velocity.z > 0)
        {
            rb.AddRelativeForce(Vector3.back * brakingCurve.Evaluate(brakingTime) * 10);
        }
        
    }

   
}
