using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public Enums.Piece PieceType => _pieceType;
    
    protected Enums.Piece _pieceType;
    protected Joint2D _joint = null;
    protected List<GameObject> _connectedList = new List<GameObject>();
    bool _canJoint = true;
    [SerializeField] float _rejointTime = 0;
    float _rejointTimer = 0;

    abstract public void SetPieceType();
    abstract public void ResolveJointConnection(Collision2D p_other);
    abstract public void ConnectJoint(Collision2D p_other);

    void Awake()
    {
        _joint = GetComponent<Joint2D>();
        SetPieceType();
    }

    void OnCollisionStay2D(Collision2D p_other) 
    {
        if (!_canJoint) 
        {
            return;
        }
        
        if (_connectedList.Find(__object => __object == p_other.gameObject)) 
        {
            return;
        }
        
        if (p_other.rigidbody)
        {
            StackManager.Instance?.AddToStack(transform);
            if (_joint)
            {
                ResolveJointConnection(p_other);
            }
        }
    }

    void OnJointBreak2D(Joint2D brokenJoint)
    {
        Debug.Log("A joint has just been broken!");
        _canJoint = false;
        _rejointTimer = 0;
    }

    IEnumerator CheckJointBreak()
    {
        while (true)
        {
            if (!_canJoint) 
            {
                while (_rejointTimer < _rejointTime)
                {
                    yield return null;
                    _rejointTimer += Time.deltaTime;
                }
                _canJoint = true;
            }
            yield return null;
        }
    }
}
