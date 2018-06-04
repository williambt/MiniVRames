using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    void Awake()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.color = Random.ColorHSV();
    }
}
