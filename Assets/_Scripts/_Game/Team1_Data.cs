using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team1_Data : MonoBehaviour
{
    public List<Unit> Team1_SelectedUnits;

    public List<Building> Team1_SelectedBuildings;



    public void ClearSelectedUnits()
    {
        for (int i = 0; i < Team1_SelectedUnits.Count; i++)
        {
            Team1_SelectedUnits[i].GetComponent<Unit_Select>().SelectDisplay.SetActive(false);
            Team1_SelectedUnits[i].GetComponent<Unit>().IsSelected = false;
            Team1_SelectedUnits.Remove(Team1_SelectedUnits[i]);
        }


        for (int i = 0; i < Team1_SelectedBuildings.Count; i++)
        {
            Team1_SelectedBuildings[i].GetComponent<Unit_Select>().SelectDisplay.SetActive(false);
            Team1_SelectedBuildings[i].GetComponent<Unit>().IsSelected = false;
            Team1_SelectedBuildings.Remove(Team1_SelectedBuildings[i]);
        }
    }
}
