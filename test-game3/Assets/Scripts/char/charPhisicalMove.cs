using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charPhisicalMove : MonoBehaviour
{

    charMoveProjection CMP;
    List<Vector2> testList = new List<Vector2>();

    public void _doBegin()
    {
        CMP = GetComponent<charMoveProjection>();
    }
    public Vector2 _GetMoveVector(Vector2 vec)
    {
        Vector2 ret = vec;
        foreach(Vector2 norm in testList)
        {
            
            ret = CMP._vecProjectino(ret,norm);
        }
        return (ret);
    }

    public void _addComponent(Vector2 norm)
    {
        bool adding = true;
        for (int i = 0; i < testList.Count; i++)
        {
            if(testList[i] == norm)
            {
                adding = false;
                break;
            }
        }
        if (adding)
        {
            testList.Add(norm);
        }
    }
    public void _deleteComponent(Vector2 norm)
    {
        bool deleting = false;
        for (int i = 0; i < testList.Count; i++)
        {
            if (testList[i] == norm)
            {
                deleting = true;
                break;
            }
        }
        if (deleting)
        {
            testList.Remove(norm);
        }
    }
}
