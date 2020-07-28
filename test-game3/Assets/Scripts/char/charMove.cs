using UnityEngine;

public class charMove : MonoBehaviour
{
    float moveSpeed = 1f;
    public void _doMove(Vector2 moveVector)//1,0
    {
        
        Vector2 moveVectorTDT = new Vector2(moveVector.x*Time.deltaTime* moveSpeed, moveVector.y * Time.deltaTime* moveSpeed);//get speed move vector
        gameObject.transform.Translate(moveVectorTDT);//transform
        
    }
    public void _doSetMoveSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    public float _getMoveSpeed()
    {
        return (moveSpeed);
    }
}
