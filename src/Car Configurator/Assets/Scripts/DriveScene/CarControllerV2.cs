using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerV2 : MonoBehaviour
{
    [SerializeField]
    private GameObject carObject;

    [SerializeField]
    private GameObject[] wheelObjects;

    private float verticalInput;
    private float horizontalInput;

    public float speed = 20;
    public float turnSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        carObject = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        carObject.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        carObject.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
