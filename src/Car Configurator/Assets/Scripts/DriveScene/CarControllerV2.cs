using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerV2 : MonoBehaviour
{
    [SerializeField]
    private GameObject carObject;

    [SerializeField]
    private List<GameObject> wheelObjects = new List<GameObject>();

    private float verticalInput;
    private float horizontalInput;

    public float speed = 20;
    public float turnSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        carObject = GameObject.FindGameObjectsWithTag("Player")[0];

        foreach (GameObject wheel in GameObject.FindGameObjectsWithTag("Wheels"))
        {
            wheelObjects.Add(wheel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        carObject.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        carObject.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        foreach (GameObject wheel in wheelObjects)
        {
            wheel.transform.Rotate(-(Time.deltaTime * speed * verticalInput * 30) , 0, 0);
        }
    }
}
