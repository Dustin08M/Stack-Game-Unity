using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float blckSpeed = 2.5f;
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
        if (isMovingHor())
            spawnXpos();
        else
            spawnZpos();
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
    public void _gmFnc_MoveBlockLeft()
    {
        transform.position += Vector3.right * blckSpeed * Time.deltaTime;
        /*        if (transform.position.x < -2f || transform.position.x > 2f)
                    blckSpeed *= -1;*/
        if (transform.position.x <= -2f)
        {
            Vector3 flipPos = new Vector3(-2f, transform.position.y, transform.position.z);
            transform.position = flipPos;
            blckSpeed *= -1f;
        }
        if (transform.position.x >= 2f)
        {
            Vector3 flipPos = new Vector3(2f, transform.position.y, transform.position.z);
            transform.position = flipPos;
            blckSpeed *= -1f;
        }

    }
    public void _gmFnc_MoveBlockForward()
    {
        transform.position += Vector3.back * blckSpeed * Time.deltaTime;
        /*        if (transform.position.z < -2f || transform.position.z > 2f)
                    blckSpeed *= -1;*/
        if (transform.position.z <= -2f)
        {
            Vector3 flipPos = new Vector3(transform.position.x, transform.position.y, -2f);
            transform.position = flipPos;
            blckSpeed *= -1f;
        }
        if (transform.position.z >= 2f)
        {
            Vector3 flipPos = new Vector3(transform.position.x, transform.position.y, 2f);
            transform.position = flipPos;
            blckSpeed *= -1f;
        }
    }

    void _gmFnc_StopBlock()
    {
        blckSpeed = 0;
    }

    void spawnXpos()
    {
        Vector3 xSpawn = transform.position;
        xSpawn.x -= 2f;
        transform.position = xSpawn;
    }
    void spawnZpos()
    {
        Vector3 zSpawn = transform.position;
        zSpawn.z += 2f;
        transform.position = zSpawn;
    }

}
