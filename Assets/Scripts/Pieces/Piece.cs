using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public Enums.Piece PieceType => _pieceType;
    
    protected Enums.Piece _pieceType;
    protected Joint2D _joint = null;
    protected List<GameObject> _connectedList = new List<GameObject>();

    abstract public void SetPieceType();
    abstract public void ResolveJointConnection(Collision2D p_other);
    abstract public void ConnectJoint(Collision2D p_other);

    void Awake()
    {
        _joint = GetComponent<Joint2D>();
        SetPieceType();
    }

    void OnCollisionEnter2D(Collision2D p_other) 
    {
        if (_connectedList.Find(__object => __object == p_other.gameObject)) 
        {
            return;
        }
        
        if (p_other.rigidbody)
        {
            if (_joint)
            {
                ResolveJointConnection(p_other);
            }
        }
    }
}
