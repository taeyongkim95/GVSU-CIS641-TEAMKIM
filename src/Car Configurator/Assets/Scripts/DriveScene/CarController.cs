using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DriveableCar : System.Object
{
    public bool UseForDirectional = false;
    public CarWheel LeftWheel;
    public CarWheel RightWheel;

}

[System.Serializable]
public class CarWheel : System.Object
{
    public WheelCollider WheelCollider;
    public GameObject WheelMesh;
    public bool HasTorque = false;
    public bool HasBreake = false;

    public float GetCurrentSpeed()
    {
        return 2f * 3.14f * WheelCollider.radius * WheelCollider.rpm;
    }

}

public class CarController : MonoBehaviour
{

    public float TorqueForce = 1000f;
    public float BreakeForce = 2000f;
    public float TorqueFriction = 100f;
    public float DirectionForce = 200f;
    public float DirectionDelay = 100f;
    public bool EnableDebug = false;
    public List<DriveableCar> Cars;

    private new Rigidbody rigidbody;

    public float GetCurrentSpeed()
    {
        float total = 0;
        foreach (DriveableCar car in Cars)
        {
            total += car.LeftWheel.GetCurrentSpeed() + car.RightWheel.GetCurrentSpeed();
        }

        return total / (Cars.Count / 2);
    }

    void FixedUpdate()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody)
            throw new System.Exception("To work, the car need to have an Rigidbody attach to him!");

        foreach (DriveableCar car in Cars)
        {
            Vector3 position;
            Quaternion rotation;
            car.LeftWheel.WheelCollider.GetWorldPose(out position, out rotation);
            car.LeftWheel.WheelMesh.transform.rotation = rotation;

            car.RightWheel.WheelCollider.GetWorldPose(out position, out rotation);
            car.RightWheel.WheelMesh.transform.rotation = rotation;

            if (car.LeftWheel.HasTorque)
                car.LeftWheel.WheelCollider.motorTorque = Input.GetAxis("Vertical") * TorqueForce;
            if (car.RightWheel.HasTorque)
                car.RightWheel.WheelCollider.motorTorque = Input.GetAxis("Vertical") * TorqueForce;

            float currentFriction = Input.GetKey(KeyCode.Space) ? BreakeForce : TorqueFriction - Mathf.Abs(Input.GetAxis("Vertical") * TorqueFriction);

            if (car.LeftWheel.HasBreake)
                car.LeftWheel.WheelCollider.brakeTorque = currentFriction;
            if (car.RightWheel.HasBreake)
                car.RightWheel.WheelCollider.brakeTorque = currentFriction;

            if (car.UseForDirectional)
            {
                float directional = Mathf.Lerp(car.LeftWheel.WheelCollider.steerAngle, DirectionForce * Input.GetAxis("Horizontal"), Time.deltaTime * DirectionDelay);
                car.LeftWheel.WheelCollider.steerAngle = directional;
                car.RightWheel.WheelCollider.steerAngle = directional;
            }

            if (EnableDebug)
            {
                Debug.Log("motorTorque: " + car.LeftWheel.WheelCollider.motorTorque + " | brakeFriction: " + currentFriction);
            }
        }
    }
}
