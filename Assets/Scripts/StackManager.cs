using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class StackManager : MonoBehaviour
{
    public static StackManager Instance;

    [SerializeField] Transform _base = null;
    [SerializeField] CinemachineVirtualCamera _camera = null;

    List<Transform> _stack = new List<Transform>();

    void Awake() 
    {
        if (!Instance) 
        {
            Instance = this;
        }
        _camera.Follow = _base;
    }

    void Update() 
    {
        _camera.Follow = FindHighestItem();
    }

    public void AddToStack(Transform p_item) 
    {
        if (!_stack.Find(__item => __item == p_item)) 
        {
            _stack.Add(p_item);
        }
    }

    Transform FindHighestItem()
    {
        Transform __highest = _base;
        if (_stack.Count == 0) 
        {
            return __highest;
        }
        _stack.RemoveAll(__item => __item == null);
        
        // foreach (var __item in _stack)
        // {
        //     if (__item.position.y > __highest.position.y) 
        //     {
        //         __highest = __item;
        //     }
        // }

        _stack = _stack.OrderByDescending(__item => __item.position.y).ToList();
        __highest = _stack[0];

        return __highest;
    }
}
