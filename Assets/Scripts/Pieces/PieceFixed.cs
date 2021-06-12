using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFixed : Piece
{
    public override void SetPieceType()
    {
        _pieceType = Enums.Piece.FIXED;
    }
    
    public override void ResolveJointConnection(Collision2D p_other)
    {
        Piece __otherPiece = p_other.gameObject.GetComponent<Piece>();
        if (__otherPiece) 
        {
            if (__otherPiece.PieceType != Enums.Piece.SPRING) 
            {
                ConnectJoint(p_other);
            }
        }
        else
        {
            ConnectJoint(p_other);
        }
    }

    public override void ConnectJoint(Collision2D p_other)
    {
        FixedJoint2D __newJoint = Takashi.GameObjectUtility.CopyComponent<FixedJoint2D>(_joint as FixedJoint2D, gameObject);
        __newJoint.enableCollision = _joint.enableCollision;
        __newJoint.breakForce = _joint.breakForce;
        __newJoint.breakTorque = _joint.breakTorque;
        __newJoint.connectedBody = p_other.rigidbody;
        __newJoint.enabled = true;
        _connectedList.Add(p_other.gameObject);
    }
}
