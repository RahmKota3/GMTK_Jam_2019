using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
    
    Grid grid;

    public bool NodeExists(Vector2 pos)
    {
        Node n = grid.GetNodeAt(pos);
        if (n != null)
        {
            if (n.IsWalkable == false)
                return false;
            else
                return true;
        }
        else
        {
            return false;
        }
    }

	public List<Vector2> GetPath(Vector2 start, Vector2 target)
    {
        if (grid.GetNodeAt(target).IsWalkable == false)
            return null;

        Node startNode = grid.GetNodeAt(start);
        Node targetNode = grid.GetNodeAt(target);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node current = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
            {
                if((openSet[i].FCost < current.FCost || openSet[i].FCost == current.FCost) && openSet[i].HCost < current.HCost)
                {
                    current = openSet[i];
                }
            }

            openSet.Remove(current);
            closedSet.Add(current);

            if(current == targetNode)
            {
                return RetracePath(startNode, targetNode, target);
            }

            foreach (Node neighbour in grid.GetNeighbours(current))
            {
                if (neighbour.IsWalkable == false || closedSet.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = current.GCost + GetDistance(current, neighbour);
                if(newMovementCostToNeighbour < neighbour.GCost || openSet.Contains(neighbour) == false)
                {
                    neighbour.GCost = newMovementCostToNeighbour;
                    neighbour.HCost = GetDistance(neighbour, targetNode);
                    neighbour.Parent = current;
                    
                    if(openSet.Contains(neighbour) == false)
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }

        Debug.Log("Pathfinding: CHUJ" + "[" + target.x + ", " + target.y + "]");
        return null;
    }

    List<Vector2> RetracePath(Node start, Node end, Vector2 targetPoint)
    {
        List<Vector2> path = new List<Vector2>();
        Node current = end;

        while(current != start)
        {
            path.Add(current.WorldPosition);
            current = current.Parent;
        }

        if (NodeExists(targetPoint))
            path[0] = targetPoint;

        path.Reverse();

        return path;
    }

    int GetDistance(Node a, Node b)
    {
        int distX = Mathf.Abs(a.GridX - b.GridX);
        int distY = Mathf.Abs(a.GridY - b.GridY);

        if (distX > distY)
            return 14 * distY + 10 * (distX - distY);
        else
            return 14 * distX + 10 * (distY - distX);
    }

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    
}
