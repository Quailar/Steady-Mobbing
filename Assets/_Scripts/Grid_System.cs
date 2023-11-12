using UnityEngine;

public class Grid_System : MonoBehaviour
{
    // Variables
    public GAME_DATA Game_Data;
    public Node[,] grid;
    public Vector3 gridSize;
    public float gridScale = 2f; // Size of each grid node
    public LayerMask Walkable_Layer;
    public LayerMask Clickable_Layer;

    // Methods
    private void Awake()
    {
        Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();
        gridSize = GameObject.FindGameObjectWithTag("MapEndNode").transform.position;
    }

    private void Start()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        grid = new Node[Mathf.RoundToInt(gridSize.x), Mathf.RoundToInt(gridSize.z)];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridSize.x / 2 - Vector3.forward * gridSize.z / 2;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.z; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * gridScale + gridScale / 2) + Vector3.forward * (y * gridScale + gridScale / 2);
                bool walkable = !Physics.CheckSphere(worldPoint, gridScale / 2, Walkable_Layer);
                int movementPenalty = 0;

                // Adjust movement penalty based on tile type
                if (walkable)
                {
                    Collider[] colliders = Physics.OverlapSphere(worldPoint, gridScale / 2);
                    foreach (Collider collider in colliders)
                    {
                        if (collider.CompareTag("SideWalkTag"))
                            movementPenalty += 1;
                        else if (collider.CompareTag("CrossWalkTag"))
                            movementPenalty += 2;
                        else if (collider.CompareTag("RoadTag"))
                            movementPenalty += 5;
                    }
                }
                grid[x, y] = new Node(walkable, worldPoint, x, y, movementPenalty);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 mouseWorldPosition)
    {
        float percentX = (mouseWorldPosition.x + gridSize.x / 2) / gridSize.x;
        float percentY = (mouseWorldPosition.z + gridSize.z / 2) / gridSize.z;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.FloorToInt((gridSize.x - 1) * percentX);
        int y = Mathf.FloorToInt((gridSize.z - 1) * percentY);

        return grid[x, y];
    }

    // Gizmo Drawing
    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            foreach (Node node in grid)
            {
                Gizmos.color = node.walkable ? Color.white : Color.red;
                Gizmos.DrawWireCube(node.worldPosition, Vector3.one * gridScale);
            }
        }
    }
}
