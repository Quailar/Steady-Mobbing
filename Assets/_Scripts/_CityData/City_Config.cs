using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Config : MonoBehaviour
{
    GAME_DATA Game_Data;

    private void Start()
    {

        Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();


        ConfigureNeighborhood();

        Game_Data.Residential_Zone_List.AddRange(GameObject.FindGameObjectsWithTag("ResidentialZone"));
        Game_Data.Commercial_Zone_List.AddRange(GameObject.FindGameObjectsWithTag("CommercialZone"));
        Game_Data.Industrial_Zone_List.AddRange(GameObject.FindGameObjectsWithTag("IndustrialZone"));

        SpawnBuildings();

        Game_Data.Building_Entrance_List.AddRange(GameObject.FindGameObjectsWithTag("BuildingEntrance"));
        Game_Data.Residential_Building_List.AddRange(GameObject.FindGameObjectsWithTag("ResidentialBuilding"));
        Game_Data.Commercial_Building_List.AddRange(GameObject.FindGameObjectsWithTag("CommercialBuilding"));
        Game_Data.Industrial_Building_List.AddRange(GameObject.FindGameObjectsWithTag("IndustrialBuilding"));
        Game_Data.isMapGenerated = true;

    }

    private void ConfigureNeighborhood()
    {

        foreach (GameObject n in GameObject.FindGameObjectsWithTag("Neighborhood"))
        {
            int f = Random.Range(0, Game_Data.RESIDENTIAL_FIRST_NAME.Length);
            int l = Random.Range(0, Game_Data.RESIDENTIAL_LAST_NAME.Length);
            n.GetComponent<Neighborhood_Data>().NeighborhoodName = Game_Data.RESIDENTIAL_FIRST_NAME[f] + " " + Game_Data.RESIDENTIAL_LAST_NAME[l];
            Game_Data.Neighborhood_List.Add(n);
            if (Game_Data.activateDebugger)
            {
                Debug.Log(n.GetComponent<Neighborhood_Data>().NeighborhoodName.ToString());
            }
        }

    }


    private void SpawnBuildings()
    {
        foreach (GameObject z in Game_Data.Residential_Zone_List)
        {
            GameObject _res = Instantiate(Game_Data.PREFAB_BUILDING_BLOCK_LIST[0], z.transform.position, Quaternion.identity, transform.GetChild(0));
            Game_Data.Residential_Building_List.Add(_res);
            Game_Data.RegisteredBuildings.Add(_res.GetComponent<Building>());
        }
        foreach (GameObject z in Game_Data.Commercial_Zone_List)
        {
            GameObject _com = Instantiate(Game_Data.PREFAB_BUILDING_BLOCK_LIST[1], z.transform.position, Quaternion.identity, transform.GetChild(1));
            Game_Data.Commercial_Building_List.Add(_com);
            Game_Data.RegisteredBuildings.Add(_com.GetComponent<Building>());
        }
        foreach (GameObject z in Game_Data.Industrial_Zone_List)
        {
            GameObject _ind = Instantiate(Game_Data.PREFAB_BUILDING_BLOCK_LIST[2], z.transform.position, Quaternion.identity, transform.GetChild(2));
            Game_Data.Industrial_Building_List.Add(_ind);
            Game_Data.RegisteredBuildings.Add(_ind.GetComponent<Building>());
        }
    }

}
