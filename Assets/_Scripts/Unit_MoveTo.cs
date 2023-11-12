
using System.Collections.Generic;
using UnityEngine;


public class Unit_MoveTo : MonoBehaviour
{

    public Unit unit;
    Grid_System Grid_System;
    public Unit_PathFinder Unit_PathFinder;


    public List<Node> Path;
    public Node Path_Destination_Node;
    public Node Path_Current_Node;
    public Node Path_Next_Node;


    private void Start()
    {
        unit = GetComponent<Unit>();
        Unit_PathFinder = GetComponent<Unit_PathFinder>();
        Grid_System = GameObject.FindGameObjectWithTag("Grid_System").GetComponent<Grid_System>();
    }


    private void FixedUpdate()
    {
        if (unit.MoveTo)
        {
            Moving();
        }
    }

    public void MoveTo(Vector3 _dest)
    {
        unit.MoveTo = true;
        Path_Destination_Node = Grid_System.NodeFromWorldPoint(_dest);
        unit.Animator.SetBool("IsIdle", false);
        unit.Animator.SetBool("IsWalking", true);





        float distance = Vector3.Distance(transform.position, Path_Destination_Node.worldPosition);


        if (distance < unit.Stopping_Distance)
        {

            unit.Animator.SetBool("IsIdle", true);
            unit.Animator.SetBool("IsWalking", false);
            unit.MoveTo = false;

        }
    }

    void Moving()
    {


        Path_Next_Node = Path_Current_Node;
        unit.transform.Translate(transform.position + Path_Next_Node.worldPosition * unit.Max_MoveSpeed * Time.deltaTime, Space.World);
        unit.transform.Rotate(Path_Next_Node.worldPosition  * Time.deltaTime, Space.World);


    }

}