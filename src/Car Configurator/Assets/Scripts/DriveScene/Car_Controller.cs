using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Car_Controller : MonoBehaviour
{
    //Public Variables
    [Header("Wheel Colliders")]
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider BL;
    public WheelCollider BR;

    [Header("Wheel Transforms")]
    public Transform Fl;
    public Transform Fr;
    public Transform Bl;
    public Transform Br;

    [Header("Wheel Transforms Rotations")]
    public Vector3 FL_Rotation;
    public Vector3 FR_Rotation;
    public Vector3 BL_Rotation;
    public Vector3 BR_Rotation;

    [Header("Car Settings")]
    public float Motor_Torque = 100f;
    public float Max_Steer_Angle = 20f;
    public float  BrakeForce = 150f;

    [Space(3)]

    //These are the speeds for each gear
    //The Brake and Reverse gears appear automatically so don't worry about those
    //The Speeds MUST be in kph
    public List<int> Gears_Speed;

    [Space(3)]

    public float handBrakeFrictionMultiplier = 2;
    private float handBrakeFriction  = 0.05f;
    public float tempo;

    [Header("Boost Settings")]
    public float Boost_Motor_Torque = 300f;
    public float Motor_Torque_Normal = 100f;

    [Header("Audio Settings (Beta)")]
    public bool Enable_Audio;
    public AudioSource Engine_Sound;
    public float Max_Engine_Audio_Pitch;
    public float Min_Engine_Audio_Pitch;
    public float Min_Volume;
    public float Max_Volume;

    [Header("Other Settings")]
    public Transform Center_of_Mass;
    public  float frictionMultiplier = 3f;
    public Rigidbody Car_Rigidbody;

    [Header("Debug")] //These are variables that are read only so dont chnage them, they are only there if u wanna use them for UI like speed or RPM;
    public float RPM_FL;
    public float RPM_FR;
    public float RPM_BL;
    public float RPM_BR;

    [Space(8)]

    public float Car_Speed_KPH;
    public float Car_Speed_MPH;

    [Space(4)]

    public string Current_Gear;
    public int Current_Gear_num;

    //private Variables
    private Rigidbody rb;
    private float Brakes = 0f;
    private WheelFrictionCurve  FLforwardFriction, FLsidewaysFriction;
    private WheelFrictionCurve  FRforwardFriction, FRsidewaysFriction;
    private WheelFrictionCurve  BLforwardFriction, BLsidewaysFriction;
    private WheelFrictionCurve  BRforwardFriction, BRsidewaysFriction;

    //Private Audio Variables
    private float Forward_volume;
    private float Reverse_volume;
    private float Reverse_pitch;
    private float Forward_pitch;

    //Hidden Variables
    [HideInInspector]public float currSpeed;

    void Start(){
        //To Prevent The Car From Toppling When Turning Too Much
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Center_of_Mass.localPosition;
    }

    public void FixedUpdate(){
        //Changing Gears
        if(Gears_Speed[Current_Gear_num] < Car_Speed_KPH && Current_Gear_num != Gears_Speed.Count){
            Current_Gear_num++;
            Current_Gear = (Current_Gear_num + 1).ToString();
        }

        if(Gears_Speed[Current_Gear_num] > Car_Speed_KPH && Current_Gear_num != 0){
            Current_Gear_num--;
            Current_Gear = (Current_Gear_num + 1).ToString();
        }

        //Making The Car Move Forward or Backward
        BL.motorTorque = Input.GetAxis("Vertical") * Motor_Torque;
        BR.motorTorque = Input.GetAxis("Vertical") * Motor_Torque;

        //Making The Car Turn
        FL.steerAngle = Input.GetAxis("Horizontal") * Max_Steer_Angle;
        FR.steerAngle = Input.GetAxis("Horizontal") * Max_Steer_Angle;

        //Showing the RPM for the wheels
        RPM_FL = FL.rpm;
        RPM_BL = BL.rpm;
        RPM_FR = FR.rpm;
        RPM_BR = BR.rpm;

        //Make Car Boost
        if(Input.GetKey(KeyCode.LeftShift)){
            //Setting The Motor Torque To The Boost Torque
            Motor_Torque = Boost_Motor_Torque;
        }

        else{
            //Setting The Motor Torque Back To Normal;
            Motor_Torque = Motor_Torque_Normal;
        }

        //Make Car Drift
        WheelHit wheelHit1;
        WheelHit wheelHit2;
        WheelHit wheelHit3;
        WheelHit wheelHit4;

        FL.GetGroundHit(out wheelHit1);
        FR.GetGroundHit(out wheelHit2);
        BL.GetGroundHit(out wheelHit3);
        BR.GetGroundHit(out wheelHit4);

        if(wheelHit1.sidewaysSlip < 0 )	
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit1.sidewaysSlip *handBrakeFrictionMultiplier);

            if(tempo < 0.5) tempo = 0.5f;

        if(wheelHit1.sidewaysSlip > 0 )	
            tempo = (1 + Input.GetAxis("Horizontal") )* Mathf.Abs(wheelHit1.sidewaysSlip *handBrakeFrictionMultiplier);

            if(tempo < 0.5) tempo = 0.5f;

        if(wheelHit1.sidewaysSlip > .99f || wheelHit1.sidewaysSlip < -.99f){
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction,tempo* 3,ref velocity ,0.1f * Time.deltaTime);
            }

        if(wheelHit2.sidewaysSlip < 0 )	
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit2.sidewaysSlip *handBrakeFrictionMultiplier);

            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit2.sidewaysSlip > 0 )	
            tempo = (1 + Input.GetAxis("Horizontal") )* Mathf.Abs(wheelHit2.sidewaysSlip *handBrakeFrictionMultiplier);
        
            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit2.sidewaysSlip > .99f || wheelHit2.sidewaysSlip < -.99f){
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction,tempo* 3,ref velocity ,0.1f * Time.deltaTime);
            }

        if(wheelHit3.sidewaysSlip < 0 )	
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit3.sidewaysSlip *handBrakeFrictionMultiplier) ;
        
            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit3.sidewaysSlip > 0 )	
            tempo = (1 + Input.GetAxis("Horizontal") )* Mathf.Abs(wheelHit3.sidewaysSlip *handBrakeFrictionMultiplier);
        
            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit3.sidewaysSlip > .99f || wheelHit3.sidewaysSlip < -.99f){
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction,tempo* 3,ref velocity ,0.1f * Time.deltaTime);
            }

        if(wheelHit4.sidewaysSlip < 0 )	
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit4.sidewaysSlip *handBrakeFrictionMultiplier) ;
        
            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit4.sidewaysSlip > 0 )	
            tempo = (1 + Input.GetAxis("Horizontal") )* Mathf.Abs(wheelHit4.sidewaysSlip *handBrakeFrictionMultiplier);
        
            if(tempo < 0.5) tempo = 0.5f;
        
        if(wheelHit4.sidewaysSlip > .99f || wheelHit4.sidewaysSlip < -.99f){
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction,tempo* 3,ref velocity ,0.1f * Time.deltaTime);
            }

        else{
            handBrakeFriction = tempo;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Change gear to "R"
            Current_Gear = "R";
        }
    }

    public void Update(){

        //Rotating The Wheels So They Don't Slide
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        
        FL.GetWorldPose(out pos, out rot);
        Fl.position = pos;
        Fl.rotation = rot * Quaternion.Euler(FL_Rotation);

        FR.GetWorldPose(out pos, out rot);
        Fr.position = pos;
        Fr.rotation = rot * Quaternion.Euler(FR_Rotation);

        BL.GetWorldPose(out pos, out rot);
        Bl.position = pos;
        Bl.rotation = rot * Quaternion.Euler(BL_Rotation);

        BR.GetWorldPose(out pos, out rot);
        Br.position = pos;
        Br.rotation = rot * Quaternion.Euler(BR_Rotation);

        //Make Car Brake
        if(Input.GetKey(KeyCode.Space) == true){
            Brakes = BrakeForce;

            //Set the Current Gear to B
            Current_Gear = "B";
        }

        else{
            Brakes = 0f;
        }

        FL.brakeTorque = Brakes;
        FR.brakeTorque = Brakes;
        BL.brakeTorque = Brakes;
        BR.brakeTorque = Brakes;

        if(Enable_Audio == true){
                //Play Car Audio
            if(Input.GetKey(KeyCode.W)){
                //Play Engine Sound
                Engine_Sound.Play();

                //Adjust Engine Sound Volume To Car Motor Torque
                Forward_volume = -1f * (Motor_Torque/BR.motorTorque);

                //Adjust Engine Speed
                Forward_pitch = -1f * (BR.motorTorque/Motor_Torque);

                if(Forward_volume > Max_Volume){
                    Forward_volume = Max_Volume;

                    if(Forward_pitch > Max_Engine_Audio_Pitch){
                        Forward_pitch = Max_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    if(Forward_pitch < Min_Engine_Audio_Pitch){
                        Forward_pitch = Min_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    else{
                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }
                }

                if(Forward_volume < Min_Volume){
                    Forward_volume = Min_Volume;

                    if(Forward_pitch > Max_Engine_Audio_Pitch){
                        Forward_pitch = Max_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    if(Forward_pitch < Min_Engine_Audio_Pitch){
                        Forward_pitch = Min_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    else{
                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }
                }
            }

            if(Input.GetKey(KeyCode.S)){
                //Play Engine Sound
                Engine_Sound.Play();

                //Adjust Engine Sound Volume To Car Motor Torque
                Reverse_volume = Motor_Torque/BR.motorTorque;

                //Adjust Audio To Engine Speed
                Reverse_pitch = -1f * (BR.motorTorque/Motor_Torque);

                if(Forward_volume > Max_Volume){
                    Forward_volume = Max_Volume;

                    if(Forward_pitch > Max_Engine_Audio_Pitch){
                        Forward_pitch = Max_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    if(Forward_pitch < Min_Engine_Audio_Pitch){
                        Forward_pitch = Min_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    else{
                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }
                }

                if(Forward_volume < Min_Volume){
                    Forward_volume = Min_Volume;

                    if(Forward_pitch > Max_Engine_Audio_Pitch){
                        Forward_pitch = Max_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    if(Forward_pitch < Min_Engine_Audio_Pitch){
                        Forward_pitch = Min_Engine_Audio_Pitch;

                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }

                    else{
                        Engine_Sound.volume = Forward_volume;
                        Engine_Sound.pitch = Forward_pitch;
                    }
                }
            }
        }
        
    }
}