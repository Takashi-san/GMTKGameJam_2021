using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _playerMaxHealth = 3;
    int _playerHealth;
    
    public void SetupGame() 
    {
        // clear pieces.
        // reset camera.
        // reset pontuation.
        // reset life.
        // reset base position.

        // stop piece spawn.
        // stop base movement.
    }
    
    public void StartGame() 
    {
        // start piece spawn.
        // allow base movement.
    }

    public void EndGame() 
    {
        // stop piece spawn.
        // stop base movement.
        // show result screen.
    }
}
