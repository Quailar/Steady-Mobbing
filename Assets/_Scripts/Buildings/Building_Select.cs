using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Select : MonoBehaviour
{


    public Building building;
    public GameObject SelectDisplay;
    public Team1_Data team1_Data;

    private void Awake()
    {
        building = GetComponent<Building>();

    }


    public void CheckBuildingSelected()
    {
        if (building.IsSelected)
        {
            building.IsSelected = false;
            SelectDisplay.SetActive(false);
            team1_Data.Team1_SelectedBuildings.Remove(building);
        }
        else
        {
            building.IsSelected = true;
            SelectDisplay.SetActive(true);
            team1_Data.Team1_SelectedBuildings.Add(building);
        }

    }

}
