using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit_Select : MonoBehaviour
{
    public Unit unit;
    [SerializeField] public GameObject SelectDisplay;
    public Team1_Data team1_Data;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        team1_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<Team1_Data>();
    }


    public void CheckUnitSelected()
    {
        if (unit.IsSelected)
        {
            Debug.Log("Unit Deselect");
            SelectDisplay.SetActive(false);
            unit.IsSelected = false;

            team1_Data.Team1_SelectedUnits.Remove(unit);
            return;
        }
        if (!unit.IsSelected)
        {
            Debug.Log("Unit Selected");
            SelectDisplay.SetActive(true);
            unit.IsSelected = true;

            team1_Data.Team1_SelectedUnits.Add(unit);
            return;
        }
    }

    public void CheckUnitShiftSelect()
    {
        if (!unit.IsSelected)
        {
            SelectDisplay.SetActive(true);
            unit.IsSelected = true;

            team1_Data.Team1_SelectedUnits.Add(unit);
        }

    }



}
