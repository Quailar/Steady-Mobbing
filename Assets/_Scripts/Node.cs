using UnityEngine;

public class Node
{
    // Properties
    public Node Instance;
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public int movementPenalty;

    // Costs
    public int gCost;
    public int hCost;
    public Node parent;
    private Vector3 worldPoint;
    private int x;
    private int y;

    // Constructor

    public Node(bool walkable, Vector3 worldPoint, int x, int y, int movementPenalty)
    {
        this.walkable = walkable;
        this.worldPoint = worldPoint;
        this.x = x;
        this.y = y;
        this.movementPenalty = movementPenalty;
    }

    // F Cost Property
    public int fCost => gCost + hCost + movementPenalty;

    private void Awake(){
Instance = this;
    }
}
