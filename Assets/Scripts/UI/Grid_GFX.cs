using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid_GFX : MonoBehaviour
{
    List<EnemyUnit> enemiesInRoom = new List<EnemyUnit>();

    static Material lineMaterial;
    private void Start()
    {
        enemiesInRoom = FindObjectsOfType<EnemyUnit>().ToList();
        GameEvents.instance.enemyDestruction += EnemyDestruction;
    }

    private void EnemyDestruction(EnemyUnit obj)
    {
        enemiesInRoom.Remove(obj);
    }

    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        //Set transformation matrix for drawing to
        //match our transform
        GL.MultMatrix(transform.localToWorldMatrix);
        //Draw grid cells
        foreach (Node node in Grid.instance.grid)
        {
            GL.Begin(GL.LINES);
            GL.Color(new Color(0, 0, 0, 0.1f));
            GL.Vertex3(node.worldPosition.x + 0.5f, 0, node.worldPosition.z + 0.5f);
            GL.Vertex3(node.worldPosition.x + 0.5f, 0, node.worldPosition.z - 0.5f);
            GL.Vertex3(node.worldPosition.x + 0.5f, 0, node.worldPosition.z - 0.5f);
            GL.Vertex3(node.worldPosition.x - 0.5f, 0, node.worldPosition.z - 0.5f);
            GL.Vertex3(node.worldPosition.x - 0.5f, 0, node.worldPosition.z - 0.5f);
            GL.Vertex3(node.worldPosition.x - 0.5f, 0, node.worldPosition.z + 0.5f);
            GL.Vertex3(node.worldPosition.x - 0.5f, 0, node.worldPosition.z + 0.5f);
            GL.Vertex3(node.worldPosition.x + 0.5f, 0, node.worldPosition.z + 0.5f);
        }
        GL.End();
        GL.PopMatrix();
    }
}