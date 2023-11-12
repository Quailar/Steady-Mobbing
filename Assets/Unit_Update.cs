using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Update : MonoBehaviour
{
    public GAME_DATA Game_Data;
    public Grid_System Grid_System;
    public Unit unit;

    int updateTimer;

    private void Awake()
    {
        Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();
        Grid_System = GameObject.FindGameObjectWithTag("Grid_System").GetComponent<Grid_System>();
        unit = GetComponent<Unit>();
    }

    public void Update()
    {

        updateTimer++;
        if (updateTimer >= unit.Speed * unit.UpdateModifier) //Unit will update its location and logic every Speed * UpdateModifier frames
        {
            updateTimer = 0;
            //Debug.Log("Unit Update");
            UpdateUnit();

        }


    }


    private void UpdateUnit()
    {
        unit.GetComponent<Unit_MoveTo>().Path_Current_Node = Grid_System.NodeFromWorldPoint(transform.position);
        if (unit.Animator.GetBool("IsIdle"))
        {
            unit.IsIdle = true;
        }
        else
        {
            unit.IsIdle = false;
        }
        if (unit.Animator.GetBool("IsWalking"))
        {
            unit.IsWalking = true;
        }
        else
        {
            unit.IsWalking = false;
        }
        if (unit.Animator.GetBool("IsRunning"))
        {
            unit.IsRunning = true;
        }
        else
        {
            unit.IsRunning = false;
        }





        if (unit.MoveTo)
        {
            if (!unit.Orders.Contains(Game_Data.UNIT_ORDERS[0]))
            {
                unit.Orders.Add(Game_Data.UNIT_ORDERS[0]);
            }
        }
        else
        {
            if (unit.Orders.Contains(Game_Data.UNIT_ORDERS[0]))
            {
                unit.Orders.Remove(Game_Data.UNIT_ORDERS[0]);
            }

        }
    }
}
