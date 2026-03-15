using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBlock
{
    public static bool Split (GameObject _currentBlock, GameObject _prevBlock, bool isHorizontal)
    {
        if (isHorizontal)
        {
            Debug.Log("X AXIS");
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

            return true;
        }
        else
        {
            Debug.Log("Z AXIS");
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

            return true;
        }
    }
}
