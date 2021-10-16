using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrototypeColorEditorWindow : EditorWindow
{
    private Material[] materials = new Material[0];

    private string assetPath = "Assets/ZacksPlugins/PrototypeColor/Materials";

    Dictionary<Material, Texture2D> textureMap = new Dictionary<Material, Texture2D>();
    private Vector2 scrollPosition;

    [MenuItem("ZacksPlugins/Prototype Color")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        PrototypeColorEditorWindow window = (PrototypeColorEditorWindow)EditorWindow.GetWindow<PrototypeColorEditorWindow>("Prototype Color");
        window.Show();
        window.UpdateMaterials();
        //AssetDatabase.refre
    }

    private void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        GUILayout.BeginHorizontal();
        for (int i = 0; i < materials.Length; i++)
        {
            if(i % 3 == 0)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
            }
            Material mat = materials[i];
            Texture2D matTexture = (Texture2D)mat.mainTexture;

            if(matTexture == null)
            {
                textureMap.TryGetValue(mat, out matTexture);
                if(matTexture == null)
                {
                    matTexture = new Texture2D(1, 1, TextureFormat.RGBAFloat, false);
                    matTexture.SetPixel(0, 0, mat.color);
                    matTexture.Apply(); // not sure if this is necessary
                    textureMap.Add(mat, matTexture);
                }
            }

            GUIStyle debugStyle = new GUIStyle(EditorStyles.miniButton);
            //debugStyle.fontSize = 24;
            debugStyle.normal.textColor = Color.white;
            debugStyle.normal.background = matTexture;
            float width = (position.width / 3f) - 8f;
            debugStyle.fixedWidth = width;
            debugStyle.fixedHeight = width;
            //debugStyle.padding = new RectOffset(8, 8, 8, 8);

            if (GUILayout.Button("", debugStyle))
            {
                ApplyColor(mat);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();

        GUILayout.Space(20f);

        if(Selection.activeGameObject == null || Selection.activeGameObject.GetComponent<Renderer>() == null)
        {
            Color prevColor = GUI.color;
            GUI.contentColor = Color.red;
            GUILayout.Label("No Renderer on selected!", EditorStyles.helpBox);
            GUI.contentColor = prevColor;
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh", GUILayout.MaxWidth(120f)))
        {
            
            UpdateMaterials();
        }
        if (GUILayout.Button("Select Folder", GUILayout.MaxWidth(120f)))
        {
            EditorUtility.FocusProjectWindow();
            Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));
            EditorGUIUtility.PingObject(asset);
        }
        GUILayout.EndHorizontal();
    }

    private void UpdateMaterials()
    {
        textureMap.Clear();
        string[] assets = AssetDatabase.FindAssets("", new[] { assetPath });
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
