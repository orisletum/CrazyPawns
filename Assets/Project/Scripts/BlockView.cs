using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    public Renderer Renderer=>renderer;
    private void OnValidate()
    {
        if(renderer == null) renderer = GetComponent<Renderer>();
    }
}
