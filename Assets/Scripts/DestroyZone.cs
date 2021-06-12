using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D p_other)
    {
        Destroy(p_other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D p_other)
    {
        Destroy(p_other.gameObject);
    }
}
