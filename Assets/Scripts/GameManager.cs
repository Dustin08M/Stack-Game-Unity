using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject prevBlock;
    [SerializeField] Color BaseBlockColor;
    [SerializeField] int score;
    GameObject spawnBlock;
    bool isBlockX;

    public static GameManager Instance { get; private set; }

    public static event Action <int> OnScoreChanged;
    public static event Action OnStackPressed;
    public static event Action isBlockHor;
    // Start is called before the first frame update


    private void OnEnable()
    {
        BlockColor.SetCurColorBlock += _gmFnc_SetBlockColor;
    }
    private void OnDestroy()
    {
        BlockColor.SetCurColorBlock -= _gmFnc_SetBlockColor;
    }

    void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
        Instance = this;
    }
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

    void _gmFnc_PlaceBlock() // Step 1
    {
        OnStackPressed?.Invoke();
        isBlockX = !isBlockX;
        _gmFnc_CheckGap();
    }
    void _gmFnc_CheckGap() // Step 2
    {
        MoveBlock moveBlock = spawnBlock.GetComponent<MoveBlock>();
        bool hasBlockLeft = SplitBlock.Split(spawnBlock, prevBlock, moveBlock.IsHorizontal);
        if (!hasBlockLeft)
        {
            Debug.Log("Game Over");
            return;
        }
        OnScoreChanged?.Invoke(1);
        prevBlock = spawnBlock;
        _gmFnc_SpawnBlock();
    }

    void _gmFnc_SpawnBlock() // Step3
    {
        spawnBlock = BlockSpawner.Spawn(prevBlock, blockPrefab, isBlockX);
    }
    void _gmFnc_SetBlockColor()
    {
        BaseBlockColor = prevBlock.GetComponent<Renderer>().material.color;
        blockPrefab.GetComponent<Renderer>().material.color = BaseBlockColor;
/*        Color newColor = Function_Extension.GetNextStackColor();
        CycleColor.SetCurrentBlockColor(spawnBlock.GetComponent<Renderer>(), newColor);*/
    }
}
