using UnityEngine;

public class charMove : MonoBehaviour
{
    float moveSpeed = 1f;

    bool isMoved = false;
    bool side = false;
    public void _doMove(Vector2 moveVector) //1,0 Moves the character with the given vector.
    {
        
        Vector2 moveVectorTDT = new Vector2(moveVector.x*Time.deltaTime* moveSpeed, moveVector.y * Time.deltaTime* moveSpeed);//get speed move vector
        gameObject.transform.Translate(moveVectorTDT);//transform

        if (moveVector == new Vector2(0, 0)) isMoved = false;
        else isMoved = true;
        side = moveVector.x > 0 ? false : moveVector.x < 0 ? true : side;

    }

    public void _doSetMoveSpeed(float _moveSpeed) //Sets the movespeed of the character.
    {
        moveSpeed = _moveSpeed;
    }

    public float _getMoveSpeed() //Returns character's movespeed.
    {
        return (moveSpeed);
    }

    public bool getIsMoved()
    {
        return (isMoved);
    }
    public bool getSide()
    {
        return (side);
    }
}
