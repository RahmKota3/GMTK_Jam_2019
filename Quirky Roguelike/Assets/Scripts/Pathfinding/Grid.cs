using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public bool DisplayGizmos = false;

    public LayerMask UnwalkableMask;

    public List<Node> Path;

    public Color ColorWalkable;
    public Color ColorUnwalkable;

    public Vector2 WorldSize;
    public float NodeRadius;
    Node[,] grid;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.GridX + x;
                int checkY = node.GridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    neighbours.Add(grid[checkX, checkY]);
            }
        }

        return neighbours;
    }
    
    public Node GetNodeAt(Vector2 worldPos)
    {
        float percentX = (worldPos.x + WorldSize.x / 2) / WorldSize.x;
        float percentY = (worldPos.y + WorldSize.y / 2) / WorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        
        return grid[x, y];
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * WorldSize.x / 2 - Vector2.up * WorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + NodeRadius) + 
                    Vector2.up * (y * nodeDiameter + NodeRadius);

                bool walkable = !(Physics2D.OverlapCircle(worldPoint, NodeRadius - 0.1f, UnwalkableMask));

                grid[x, y] = new Node(worldPoint, x, y, walkable);
            }
        }
    }

    private void Start()
    {
        nodeDiameter = NodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(WorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(WorldSize.y / nodeDiameter);

        CreateGrid();
    }

    private void OnDrawGizmos()
    {
        if (DisplayGizmos == false)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(WorldSize.x, WorldSize.y));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.IsWalkable) ? ColorWalkable : ColorUnwalkable;
                //if(Path != null && Path.Contains(n))
                //{
                //    Gizmos.color = Color.black;
                //}
                Gizmos.DrawCube(n.WorldPosition, Vector3.one * (nodeDiameter - 0.1f));
            }
        }
    }

}
