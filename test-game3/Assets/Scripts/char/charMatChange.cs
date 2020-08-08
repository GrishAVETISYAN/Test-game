using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMatChange : MonoBehaviour
{
    public void _doChangeMat (Material mat, string name) //replaces the material of the target object with the given one.
    {
        GameObject targetObj = GameObject.Find(name);
        targetObj.GetComponent<Renderer>().material = mat;
    }
}
