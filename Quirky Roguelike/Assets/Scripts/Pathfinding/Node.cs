using UnityEngine;

public class Node {

    public Vector2 WorldPosition { get; private set; }

    public int GridX;
    public int GridY;

    public bool IsWalkable { get; private set; }

    public int GCost;
    public int HCost;
    public int FCost { get { return GCost + HCost; } }

    public Node Parent;

    public Node(Vector2 worldPos, int x, int y, bool isWalkable)
    {
        WorldPosition = worldPos;
        GridX = x;
        GridY = y;
        IsWalkable = isWalkable;
    }

}
