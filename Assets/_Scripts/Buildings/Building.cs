using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("============BuildingData============")]
    //#############################################

    [Header("====================BUILDING REGISTRATION DATA====================")]
    public int ID;
    public Building Instance;
    public enum BuildingClass { Residential, Commercial, Industrial }
    public BuildingClass Building_Class;

    public List<GameObject> Entrance;
    public List<GameObject> SecurityPersonel;
    public int SecurityLevel;
    public int LandValue;
    public int Level;
    public int Influence;
    public int WarehouseSpace;
    public bool IsForSale;
    public int Price;
    public bool IsSelected;
    public bool IsExplored;
    public Vector3 Location;

}
