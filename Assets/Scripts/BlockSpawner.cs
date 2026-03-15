using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner
{
    public static GameObject Spawn(GameObject _prevBlock, GameObject _prefab, bool isBlockX)
    {
        Vector3 spawnPos = _prevBlock.transform.position + Vector3.up * .3f;

        if (isBlockX)
        {
            spawnPos.x -= 2f;
        }
        else
            spawnPos.z += 2f;
        
        GameObject currentBlock = Object.Instantiate(_prefab,spawnPos,Quaternion.identity);

        currentBlock.transform.position = spawnPos;
        currentBlock.transform.localScale = _prevBlock.transform.localScale;

        MoveBlock mb = currentBlock.GetComponent<MoveBlock>();
        mb.IsHorizontal = isBlockX;

        return currentBlock;
    }
}
