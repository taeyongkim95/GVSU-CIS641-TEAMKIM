using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataManager : MonoBehaviour
{
    public static CarDataManager instance;

    public Material _paintMat;
    public Material _seatMat;
    public Material _rimMat;
    public float _glossyVal;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this.gameObject);
        }

        _paintMat = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material;
        _seatMat = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material;
        _rimMat = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<MeshRenderer>().material;
        _glossyVal = _paintMat.GetFloat("_Metallic");
    }

    // Start is called before the first frame update
    void Start()
    {
        ApplyValues();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyValues();
    }

    public void ApplyValues()
    {
        _paintMat.SetFloat("_Metallic", _glossyVal);
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = _paintMat;
        gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _seatMat;
        gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<MeshRenderer>().material = _rimMat;
        gameObject.transform.GetChild(3).transform.GetChild(2).GetComponent<MeshRenderer>().material = _rimMat;
        gameObject.transform.GetChild(4).transform.GetChild(2).GetComponent<MeshRenderer>().material = _rimMat;
        gameObject.transform.GetChild(5).transform.GetChild(2).GetComponent<MeshRenderer>().material = _rimMat;
    }
}