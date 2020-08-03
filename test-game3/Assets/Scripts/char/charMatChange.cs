using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMatChange : MonoBehaviour
{
    public void _doChangeMat (Material mat, string name)
    {
        GameObject targetObj = GameObject.Find(name);
        targetObj.GetComponent<Renderer>().material = mat;
        Debug.Log(targetObj.GetComponent<Renderer>().material);
    }
}
