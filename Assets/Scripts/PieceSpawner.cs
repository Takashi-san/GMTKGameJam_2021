using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] bool _doSpawn = true;
    [SerializeField] List<GameObject> _piecePrefabs = null;
    [SerializeField] float _spawnTime = 1;
    [SerializeField] Transform _pieceBucket = null;

    float _spawnTimer = 0;

    void Update () 
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer > _spawnTime)
        {
            _spawnTimer -= _spawnTime;
            if (_doSpawn)
            {
                SpawnPiece();
            }
        }
    }

    void SpawnPiece() 
    {
        int __pieceIndex = Random.Range(0, _piecePrefabs.Count);
        GameObject __newPiece = Instantiate(_piecePrefabs[__pieceIndex], transform.position, Quaternion.identity);
        __newPiece.transform.parent = _pieceBucket;
    }
}
