using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Inputs : MonoBehaviour
{
    public Grid_System GridSystem;
    public Unit_PathFinder Pathfinder;
    public Team1_Data team1_Data;
    public bool SHIFT_SELECT;



    public Vector3 Mouse_ScreenPosition;
    public Vector3 Mouse_WorldPosition;
    [SerializeField] public Node Mouse_NodePosition;
    public Vector3 obj_WorldVector;
    public int raycastDist = 1000;
    bool toggle = false;

    private void Awake()
    {
        team1_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<Team1_Data>();
        GridSystem = GameObject.FindGameObjectWithTag("Grid_System").GetComponent<Grid_System>();

    }

    private void Update()
    {
        Mouse_ScreenPosition = Input.mousePosition;


        if (Input.GetMouseButtonDown(0))
        {
            GetLeftClick();

        }

        if (Input.GetMouseButtonDown(1))
        {
            GetRightClick();
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            //Zoom used in camera controller

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            LeftShiftSelect();
        }
        else
        {
            LeftShiftRelease();
        }
    }




    //############################################### MOUSE INPUT ####################################################
    //################################################################################################################
    public void GetLeftClick()
    {
        Mouse_ScreenPosition = Input.mousePosition;




        Ray ray = Camera.main.ScreenPointToRay(Mouse_ScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDist, GridSystem.Clickable_Layer))//Clickable Layer
        {
            Pathfinder = hit.collider.GameObject().GetComponent<Unit_PathFinder>();
            // obj_WorldVector = GridSystem.NodeFromWorldPoint(hit.point);
            obj_WorldVector = hit.collider.transform.position;

            if (!SHIFT_SELECT)
            {
                CheckClickedObject(hit);
            }
            else
            {
                CheckShiftSelect(hit);
            }
        }
        else if (Physics.Raycast(ray, out RaycastHit hit2, raycastDist, GridSystem.Walkable_Layer))//Walkable Layer
        {
            Pathfinder = hit2.collider.GameObject().GetComponent<Unit_PathFinder>();
            // obj_WorldVector = GridSystem.NodeFromWorldPoint(hit2.point);
            obj_WorldVector = hit2.collider.transform.position;

            if (!SHIFT_SELECT)
            {
                if (team1_Data.Team1_SelectedUnits != null)
                {
                    team1_Data.ClearSelectedUnits();
                }
            }

        }
        else
        {
            // Debug.Log("Swing and a MISS!!");


            if (team1_Data.Team1_SelectedUnits != null)
            {
                team1_Data.ClearSelectedUnits();
            }
        }

    }



    public void CheckClickedObject(RaycastHit hit)
    {
        if ((hit.collider.gameObject.GetComponent("Unit_Select") as Unit_Select) != null)
        {

            hit.collider.gameObject.GetComponent<Unit_Select>().CheckUnitSelected();

        }
        if ((hit.collider.gameObject.GetComponent("Building_Select") as Building_Select) != null)
        {
            hit.collider.gameObject.GetComponent<Building_Select>().CheckBuildingSelected();

        }
    }

    public void CheckShiftSelect(RaycastHit hit)
    {
        if ((hit.collider.gameObject.GetComponent("Unit_Select") as Unit_Select) != null)
        {

            hit.collider.gameObject.GetComponent<Unit_Select>().CheckUnitShiftSelect();

        }
    }


    private void GetRightClick()
    {
        Mouse_ScreenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Mouse_ScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit3, raycastDist, GridSystem.Walkable_Layer))//Walkable Layer
        {


            Pathfinder = hit3.collider.GameObject().GetComponent<Unit_PathFinder>();
            obj_WorldVector = hit3.collider.transform.position;

            if (team1_Data.Team1_SelectedUnits != null)
            {
                foreach (Unit su in team1_Data.Team1_SelectedUnits)
                {


                    su.GetComponent<Unit_MoveTo>().MoveTo(obj_WorldVector);//Vector3 Destination



                }

            }
            team1_Data.ClearSelectedUnits();

        }
    }

    // KEYBOARD INPUT


    public void LeftShiftSelect()
    {
        SHIFT_SELECT = true;
        toggle = false;


    }
    public void LeftShiftRelease()
    {
        if (!toggle)
        {
            toggle = true;
            SHIFT_SELECT = false;



        }
    }
}
