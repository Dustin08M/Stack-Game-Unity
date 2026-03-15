using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject prevBlock;
    [SerializeField] int score;
    GameObject spawnBlock;
    bool isBlockX;

    public static event Action OnStackPressed;
    public static event Action isBlockHor;
    // Start is called before the first frame update

    void Start()
    {
        isBlockX = Function_Extension.Rndmz_BlockMovement();
        Debug.Log($"Block is set to {isBlockX}");
        _gmFnc_SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        // Stops the block then check for the gaps before spawning again
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gmFnc_PlaceBlock();
        }
    }

    void _gmFnc_SpawnBlock()
    {
        spawnBlock = BlockSpawner.Spawn(prevBlock,blockPrefab, isBlockX);
    }

    void _gmFnc_PlaceBlock()
    {
        OnStackPressed?.Invoke();
        isBlockX = !isBlockX;
        _gmFnc_CheckGap();
    }
    void _gmFnc_CheckGap()
    {
        MoveBlock moveBlock = spawnBlock.GetComponent<MoveBlock>();
        bool hasBlockLeft = SplitBlock.Split(spawnBlock, prevBlock, moveBlock.IsHorizontal);
        if (!hasBlockLeft)
        {
            Debug.Log("Game Over");
            return;
        }
        prevBlock = spawnBlock;
        _gmFnc_SpawnBlock();
    }
}
