
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Unit_PathFinder : MonoBehaviour
{
    // Variables
    GAME_DATA Game_Data;
    Grid_System Grid_System;
    public Node StartNode;
    public Node EndNode;
    public Unit Unit;

    // Methods
    void Start()
    {
        Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();
        Grid_System = GameObject.FindGameObjectWithTag("Grid_System").GetComponent<Grid_System>();
        Unit = GetComponent<Unit>();
    }

    public List<Node> GetPath(Vector3 _dest)
    {


        FindNodes(_dest);
        List<Node> _path = FindPath(StartNode, EndNode);
        return _path;
    }

    private void FindNodes(Vector3 _dest)
    {
        StartNode = Grid_System.NodeFromWorldPoint(transform.position);
        EndNode = Grid_System.NodeFromWorldPoint(_dest);
        GetNeighbours(StartNode);
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < Grid_System.gridSize.x && checkY >= 0 && checkY < Grid_System.gridSize.z)
                {
                    neighbours.Add(Grid_System.grid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

    public List<Node> FindPath(Node node_startPos, Node node_targetPos)
    {
        Node startNode = node_startPos;
        Node targetNode = node_targetPos;

        List<Node> openSetNode = new List<Node>();
        HashSet<Node> closedSetNode = new HashSet<Node>();

        openSetNode.Add(startNode);//Changes count to 1


        while (openSetNode.Count > 0)
        {
            Node currentNode = openSetNode[0];

            for (int i = 1; i < openSetNode.Count; i++)///1or0?  count was set to one next we check 1.  Cant check xero so looks right
            {
                if (openSetNode[i].fCost < currentNode.fCost || (openSetNode[i].fCost == currentNode.fCost && openSetNode[i].hCost < currentNode.hCost))
                {
                    currentNode = openSetNode[i];
                }
            }

            openSetNode.Remove(currentNode);
            closedSetNode.Add(currentNode);












            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (Node neighbour in GetNeighbours(currentNode))
            {
                if (!neighbour.walkable || closedSetNode.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour) + neighbour.movementPenalty;
                if (newMovementCostToNeighbour < neighbour.gCost || !openSetNode.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSetNode.Contains(neighbour))
                    {
                        openSetNode.Add(neighbour);
                    }
                }
            }

        }
        return null;
    }


    List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
            Unit.GetComponent<Unit_MoveTo>().Path_Current_Node = currentNode;
        }

        path.Reverse();
        return path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        return dstX > dstY ? 14 * dstY + 10 * (dstX - dstY) : 14 * dstX + 10 * (dstY - dstX);
    }
}
