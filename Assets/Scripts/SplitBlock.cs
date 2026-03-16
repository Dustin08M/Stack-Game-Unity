using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SplitBlock
{
    public static bool Split (GameObject _currentBlock, GameObject _prevBlock, bool isHorizontal)
    {
        if (isHorizontal)
        {
            Debug.Log("X AXIS");

            //Scale will be applied to the dead block
            float originalSize = _currentBlock.transform.localScale.x;

            //Calculate to get the overlap of the block
            float gapAmount = _currentBlock.transform.position.x - _prevBlock.transform.position.x;
            float blockSize = _prevBlock.transform.localScale.x;
            float overlap = blockSize - Mathf.Abs(gapAmount);

            if (overlap <= 0)
            {
                return false;
            }

            //Resize the block based
            Vector3 scale = _currentBlock.transform.localScale;
            scale.x = overlap;
            _currentBlock.transform.localScale = scale;

            //Check if the resized block aligns to the previous block
            float newX = _prevBlock.transform.position.x + (gapAmount / 2);
            _currentBlock.transform.position = new Vector3(newX, _currentBlock.transform.position.y, _currentBlock.transform.position.z);

            //Spawn deadBlock

            float dbSize = originalSize - overlap;
            GameObject deadBlock = Object.Instantiate(_currentBlock);
            deadBlock.name = "DeadBlock".ToString();
            deadBlock.GetComponent<MoveBlock>().isMoving = false;
            deadBlock.AddComponent<Rigidbody>();

            Vector3 deadScale = deadBlock.transform.localScale;
            deadScale.x = dbSize;
            deadBlock.transform.localScale = deadScale;

            //Set dead X Pos
            float deadX = newX + (overlap / 2 + dbSize / 2) * Mathf.Sign(gapAmount);
            deadBlock.transform.position = new Vector3(deadX, _currentBlock.transform.position.y, _currentBlock.transform.position.z);
            
            return true;
        }
        else
        {
            Debug.Log("Z AXIS");

            //Scale will be applied to the dead block
            float originalSize = _currentBlock.transform.localScale.x;


            float gapAmount = _currentBlock.transform.position.z - _prevBlock.transform.position.z;
            float blockSize = _prevBlock.transform.localScale.z;
            float overlap = blockSize - Mathf.Abs(gapAmount);

            if (overlap <= 0)
            {
                return false;
            }

            Vector3 scale = _currentBlock.transform.localScale;
            scale.z = overlap;
            _currentBlock.transform.localScale = scale;

            float newZ = _prevBlock.transform.position.z + (gapAmount / 2);
            _currentBlock.transform.position = new Vector3(_currentBlock.transform.position.x, _currentBlock.transform.position.y, newZ);


            //Spawn deadBlock

            float dbSize = originalSize - overlap;
            GameObject deadBlock = Object.Instantiate(_currentBlock);
            deadBlock.name = "DeadBlock".ToString();
            deadBlock.GetComponent<MoveBlock>().isMoving = false;
            deadBlock.AddComponent<Rigidbody>();

            Vector3 deadScale = deadBlock.transform.localScale;
            deadScale.z = dbSize;
            deadBlock.transform.localScale = deadScale;

            //Set dead X Pos
            float deadZ = newZ + (overlap / 2 + dbSize / 2) * Mathf.Sign(gapAmount);
            deadBlock.transform.position = new Vector3(_currentBlock.transform.position.x, _currentBlock.transform.position.y, deadZ);

            return true;
        }
    }
}
