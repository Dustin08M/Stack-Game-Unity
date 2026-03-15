using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float blckSpeed = 2.5f;
    public bool IsHorizontal;

    [SerializeField] float moveLimit = 3f;
    bool isMoving = true;

    private void OnEnable()
    {
        GameManager.OnStackPressed += _gmFnc_StopBlock;
    }
    private void OnDisable()
    {
        GameManager.OnStackPressed -= _gmFnc_StopBlock;
    }
    void Update()
    {
        if (!isMoving) return;

        Move();
    }
    void Move()
    {
        Vector3 direction = IsHorizontal ? Vector3.right : Vector3.back;

        transform.position += direction * blckSpeed * Time.deltaTime;

        if (IsHorizontal)
        {
            if (transform.position.x <= -moveLimit || transform.position.x >= moveLimit)
            {
                FlipX();
            }
        }
        else
        {
            if (transform.position.z <= -moveLimit || transform.position.z >= moveLimit)
            {
                FlipZ();
            }
        }
    }

    void FlipX()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -moveLimit, moveLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        blckSpeed *= -1f;
    }

    void FlipZ()
    {
        float clampedZ = Mathf.Clamp(transform.position.z, -moveLimit, moveLimit);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);

        blckSpeed *= -1f;
    }
    
    void _gmFnc_StopBlock()
    {
        isMoving = false;
    }
}
