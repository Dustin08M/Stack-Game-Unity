using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject nextBlock;
    [SerializeField] int score;
    GameObject spawnBlock;
    float heightPos = .4f;

    public static event Action OnStackPressed;
    // Start is called before the first frame update
    void Start()
    {
        _gmFnc_SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnStackPressed?.Invoke();
            _gmFnc_PlaceBlock();
        }
    }

    void _gmFnc_SpawnBlock()
    {
        Vector3 blockHeight = nextBlock.transform.position + Vector3.up * heightPos;
        spawnBlock = Instantiate(blockPrefab, blockHeight, Quaternion.identity);
    }

    void _gmFnc_PlaceBlock()
    {
        nextBlock = spawnBlock;
        _gmFnc_SpawnBlock();
    }
}
