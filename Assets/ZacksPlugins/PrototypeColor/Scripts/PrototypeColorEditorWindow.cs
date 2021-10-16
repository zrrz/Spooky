using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrototypeColorEditorWindow : EditorWindow
{
    private Material[] materials = new Material[0];

    [MenuItem("ZacksPlugins/Prototype Color")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        PrototypeColorEditorWindow window = (PrototypeColorEditorWindow)EditorWindow.GetWindow<PrototypeColorEditorWindow>("Prototype Color");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        for (int i = 0; i < materials.Length; i++)
        {
            if(i % 3 == 0)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
            }
            Material mat = materials[i];
            Color prevColor = GUI.backgroundColor;
            GUI.backgroundColor = mat.color;
            if(GUILayout.Button(""))
            {
                ApplyColor(mat);
            }
            GUI.backgroundColor = prevColor;
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20f);

        if (GUILayout.Button("Refresh", GUILayout.MaxWidth(120f)))
        {
            UpdateMaterials();
        }
    }

    private void UpdateMaterials()
    {
        string[] assets = AssetDatabase.FindAssets("", new[] { "Assets/ZacksPlugins/PrototypeColor/Materials" });
        materials = new Material[assets.Length];
        for (int i = 0; i < assets.Length; i++)
        {
            string asset = assets[i];
            string path = AssetDatabase.GUIDToAssetPath(asset);
            Material material = (Material)AssetDatabase.LoadAssetAtPath(path, typeof(Material));
            materials[i] = material;
        }
    }

    //private void MakeNewColor(Color color)
    //{

    //}

    private void ApplyColor(Material mat)
    {
        var gameObjects = Selection.gameObjects;
        {
            foreach(var go in gameObjects)
            {
                Renderer rend = go.GetComponent<Renderer>();
                if(rend)
                {
                    rend.material = mat;
                }
            }
        }
    }
}
