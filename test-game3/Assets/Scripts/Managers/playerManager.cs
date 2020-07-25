using UnityEngine;

public class playerManager : MonoBehaviour
{
    charMove CM;
    charControll CC;
    serializedVector SV;
    charPhisicalMove CPM;
    Vector2 CC_moveVector;

    void Start()
    {

        CM = GetComponent<charMove>();
        CC = GetComponent<charControll>();
        SV = GetComponent<serializedVector>();
        CPM = GetComponent<charPhisicalMove>();
    }

    
    void Update()
    {   
       

        CC_moveVector = CPM._GetMoveVector(CC._getVector());

        CM._doMove              (CC_moveVector);
        SV._doSerializedVector  (CC_moveVector);
    }
}
