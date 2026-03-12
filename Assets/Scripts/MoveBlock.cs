using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public int blckSpeed = 3;
    public bool IsHorizontal;


    private void OnEnable()
    {
        GameManager.OnStackPressed += _gmFnc_StopBlock;
    }
    private void OnDisable()
    {
        GameManager.OnStackPressed -= _gmFnc_StopBlock;
    }
    private void Start()
    {
        IsHorizontal = Function_Extension.Rndmz_BlockMovement(); //if false, move forward, if true move horizontal
        Debug.Log($"Value is {IsHorizontal}");
    }

    void Update()
    {
        if (isMovingHor())
        {
            _gmFnc_MoveBlockLeft();
        }
        else
            _gmFnc_MoveBlockForward();

    }
    bool isMovingHor()
    {
        return IsHorizontal;
    }

    //"_gmFnc" simply means "Game Function", followed by name of function
    void _gmFnc_MoveBlockLeft()
    {
        transform.position += Vector3.left * blckSpeed * Time.deltaTime;
        if (transform.position.x < -2f || transform.position.x > 2f)
            blckSpeed *= -1;
    }
    void _gmFnc_MoveBlockForward()
    {
        transform.position += Vector3.forward * blckSpeed * Time.deltaTime;
        if (transform.position.z > 2f || transform.position.z < -2f)
            blckSpeed *= -1;
    }

    void _gmFnc_StopBlock()
    {
        blckSpeed = 0;
    }
}
