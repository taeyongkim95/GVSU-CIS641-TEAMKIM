using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossySlider : MonoBehaviour
{
    [SerializeField]
    private GameObject carBody;

    public static float glossyVal;

    public void SetGlossyValue(float newVal)
    {
        carBody.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", newVal);
        glossyVal = newVal;
    }
}
