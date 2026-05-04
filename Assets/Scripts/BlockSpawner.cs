using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockSpawner
{
    public static GameObject Spawn(GameObject _prevBlock, GameObject _prefab, bool isBlockX)
    {
        Vector3 spawnPos = _prevBlock.transform.position + Vector3.up * .3f;
        float PosLimit = 3.5f;

        if (isBlockX)
        {
            spawnPos.x -= PosLimit;
        }
        else
            spawnPos.z += PosLimit;
        
        GameObject currentBlock = Object.Instantiate(_prefab,spawnPos,Quaternion.identity);

        currentBlock.GetComponent<Renderer>().material.color = Function_Extension.GetNextStackColor();

        currentBlock.transform.position = spawnPos;
        currentBlock.transform.localScale = _prevBlock.transform.localScale;

        MoveBlock mb = currentBlock.GetComponent<MoveBlock>();
        mb.IsHorizontal = isBlockX;

        return currentBlock;
    }
}
