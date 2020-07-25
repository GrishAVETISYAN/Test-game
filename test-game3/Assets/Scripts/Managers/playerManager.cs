using UnityEngine;

public class playerManager : MonoBehaviour
{
    charMove CM;
    charControll CC;
    serializedVector SV;
    charMoveProjection CMP;
    Vector2 CC_moveVector;

    void Start()
    {

        CM = GetComponent<charMove>();
        CC = GetComponent<charControll>();
        SV = GetComponent<serializedVector>();
        CMP = GetComponent<charMoveProjection>();
    }

    
    void Update()
    {   
        /*
        if(transform.position.y>=0)
        CC_moveVector = CMP._vecProjectino(CC._getVector(), new Vector2(0,-1f));
        else
        {
            CC_moveVector = CC._getVector();
        }*/

        CC_moveVector = CC._getVector();

        CM._doMove              (CC_moveVector);
        SV._doSerializedVector  (CC_moveVector);
    }
}
