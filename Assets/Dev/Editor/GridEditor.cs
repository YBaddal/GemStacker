using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameGrid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameGrid grid = (GameGrid)target;
        if (GUILayout.Button("Generate"))
            grid.Create();

        if (GUILayout.Button("Reset"))
            grid.Reset();
    }
}
