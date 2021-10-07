using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintButton : MonoBehaviour
{
    [SerializeField]
    private GameObject carBody;
    // Start is called before the first frame update
    void Start()
    {
        carBody = GameObject.FindGameObjectsWithTag("CarBody")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCarMaterial(Material paintMaterial) {
        carBody.GetComponent<MeshRenderer>().material = paintMaterial;
    }
}
