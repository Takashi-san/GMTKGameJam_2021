using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpring : Piece
{
    public override void SetPieceType()
    {
        _pieceType = Enums.Piece.SPRING;
    }
    
    public override void ResolveJointConnection(Collision2D p_other)
    {
        ConnectJoint(p_other);
    }

    public override void ConnectJoint(Collision2D p_other)
    {
        SpringJoint2D __originalJoint = _joint as SpringJoint2D;
        SpringJoint2D __newJoint = Takashi.GameObjectUtility.CopyComponent<SpringJoint2D>(__originalJoint, gameObject);
        __newJoint.enableCollision = __originalJoint.enableCollision;
        __newJoint.autoConfigureConnectedAnchor = __originalJoint.autoConfigureConnectedAnchor;
        __newJoint.autoConfigureDistance = __originalJoint.autoConfigureDistance;
        __newJoint.connectedBody = p_other.rigidbody;
        __newJoint.enabled = true;
        _connectedList.Add(p_other.gameObject);
    }
}
