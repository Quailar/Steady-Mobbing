using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Config : MonoBehaviour
{
    GAME_DATA Game_Data;

    [SerializeField] public Building building;
    public bool FirstRun;

    void Awake()
    {
        building = GetComponent<Building>();
                Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();
    }

    private void Start()
    {

        building.Location = transform.position;
    }

    private void Update()
    {
        if (!FirstRun)
        {
            ConfigureBuilding();
            FirstRun = true;
        }
    }

    private void ConfigureBuilding()
    {
        RegisterBuilding(building.Building_Class.GetHashCode());

        SetBio();

        if (Game_Data.activateDebugger)
        {
            print("Building Online: " + building.Building_Class.ToString());
        }
    }

    private void RegisterBuilding(int _type)
    {
        building.ID = Math.Abs(building.GetInstanceID());
        building.Instance = building;
        Game_Data.RegisteredBuildings.Add(building);
        switch (_type)
        {
            case 2:
                Game_Data.Industrial_Building_List.Add(building.gameObject);
                building.WarehouseSpace = UnityEngine.Random.Range(7, 10);
                building.LandValue = UnityEngine.Random.Range(1, 3);
                int i = UnityEngine.Random.Range(0, 1);//Randomizing which building will be available for purchase
                if (i == 0)
                    building.IsForSale = false;
                else
                    building.IsForSale = true;
                break;
            case 1:
                Game_Data.Commercial_Building_List.Add(building.gameObject);
                building.WarehouseSpace = UnityEngine.Random.Range(3, 7);
                building.LandValue = UnityEngine.Random.Range(3, 5);
                i = UnityEngine.Random.Range(0, 1);
                if (i == 0)
                    building.IsForSale = false;
                else
                    building.IsForSale = true;
                break;
            case 0:
                Game_Data.Residential_Building_List.Add(building.gameObject);
                building.LandValue = UnityEngine.Random.Range(1, 5);
                building.WarehouseSpace = 0;
                break;
        }
    }

    private void SetBio()
    {
        building.Level = 1;
        building.Influence = 1;
        building.Price = (building.WarehouseSpace + building.Level) * (building.LandValue + building.Influence) * 222;
    }

}