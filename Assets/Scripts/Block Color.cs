using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockColor : MonoBehaviour
{
    [field: SerializeField] Material _currentBlockColor { get; set; }
    Renderer rend { get; set; }
    [SerializeField] Color color;
    public static event Action SetCurColorBlock;
    // Start is called before the first frame update
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    void Start()
    {
        if (this.gameObject.name == "Base" )
        {
            color = Function_Extension.SetRandomColor();
            Function_Extension.SetCurrentBlockColor(rend, color);
            SetCurColorBlock?.Invoke();

        }
        else
        {
            return;
        }
    }
}
