using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    [Header("Prefab (must be a Cube)")]
    public GameObject cubePrefab;

    [Header("Fractal")]
    [Range(0, 10)] public int depth = 4;
    public float rootSize = 2f;

  
    [Range(0.1f, 0.9f)] public float scaleFactor = 0.5f;

    [Header("Which faces to extrude")]
    public bool extrudeUp = true;
    public bool extrudeDown = true;
    public bool extrudeLeft = true;
    public bool extrudeRight = true;
    public bool extrudeForward = true;
    public bool extrudeBack = true;

    

    void Start()
    {
     Generate();
    }

    
    public void Generate()
    {
        if (!cubePrefab)
        {
            Debug.LogError("Assign a Cube prefab.");
            return;
        }

        ClearChildren();
        GenerateRecursive(Vector3.zero, rootSize, depth);
    }

    void GenerateRecursive(Vector3 localPos, float size, int d)
    {
        
        var current = Instantiate(cubePrefab, transform);
        current.transform.localPosition = localPos;
        current.transform.localRotation = Quaternion.identity;
        current.transform.localScale = Vector3.one * size;

        if (d == 0) return;

        float childSize = size * scaleFactor;
        float push = (size * 0.5f) + (childSize * 0.5f);

        void Extrude(Vector3 dir)
        {
            GenerateRecursive(localPos + dir * push, childSize, d - 1);
        }

        if (extrudeUp)      Extrude(Vector3.up);
        if (extrudeDown)    Extrude(Vector3.down);
        if (extrudeLeft)    Extrude(Vector3.left);
        if (extrudeRight)   Extrude(Vector3.right);
        if (extrudeForward) Extrude(Vector3.forward);
        if (extrudeBack)    Extrude(Vector3.back);
    }

    void ClearChildren()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var child = transform.GetChild(i).gameObject;
            if (Application.isPlaying) Destroy(child);
            else DestroyImmediate(child);
        }
    }
}
