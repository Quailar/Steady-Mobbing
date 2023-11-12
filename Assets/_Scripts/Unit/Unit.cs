
using System;
using System.Collections.Generic;

using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class Unit : MonoBehaviour
{

    public int ID;
    public Unit Instance;
    public enum UnitClass { Civilian, Gangster, Police, Manager, Accountant, Lawyer, Judge, Specialty }
    public UnitClass Unit_Class;



    [SerializeField] public Animator Animator;
    [SerializeField] public List<RuntimeAnimatorController> Animation_Controllers;
    [SerializeField] public List<Avatar> Avatars;
    [SerializeField] public AudioSource Audio_Source;
    [SerializeField] public List<AudioClip> Audio_Clips;


    [SerializeField] public List<GameObject> _MHeads;
    [SerializeField] public List<GameObject> _MGlasses;
    [SerializeField] public List<GameObject> _MBodys;
    [SerializeField] public List<GameObject> _MWeapons;
    [SerializeField] public List<GameObject> _FHeads;
    [SerializeField] public List<GameObject> _FGlasses;
    [SerializeField] public List<GameObject> _FBodys;
    [SerializeField] public List<GameObject> _FWeapons;


    public string Gender;
    public int Head;
    public int Body;
    public int Weapon;
    public int Age;
    public string First_Name;
    public string Last_Name;
    public string Nick_Name;
    public string Mood;
    public string Profession;
    public int Cost_To_Hire;
    public int Cash;
    public GameObject Residence;
    public GameObject Workplace;


    public float Strength;
    public float Intelligence;
    public float Dexterity;
    public float Vision;
    public float Aim;
    public float Speed;
    public float Driving;
    public float Stealth;
    public float Total_Stats;



    public string Team;
    [SerializeField] private GameObject Squad_Members_List;
    public bool IsLieutenant;
    public float Wanted_Level;
    [SerializeField] private List<GameObject> Criminal_Record_List;
    public bool IsJailed;
    public int Time_Left_InJail;
    [Header(" ")]



    [SerializeField] private List<GameObject> Inventory = new List<GameObject>();

    public int Max_HitPoints;
    public int Current_HitPoints;
    public bool IsAlive;
    public bool IsHospitalized;
    public int TimeLeftInHospital;
    public bool IsTraining;
    public int TimeLeftInTraining;
    public bool IsBleeding;
    public bool IsInjured;
    public int Time_Till_Death;

    public bool IsIdle;
    public bool IsSelected;
    public bool IsWalking;
    public bool IsRunning;
    public bool IsBusy;
    public bool IsDriving;
    public bool IsUnderAttack;
    public bool IsBeating;
    public bool IsStabbing;
    public bool IsShooting;
    public bool IsFleeing;

    public GameObject Follow_Lieutenant;

    
        //########################################################################################################################

    [SerializeField] public List<string> Orders;


        //########################################################################################################################



    public float Max_MoveSpeed;
    public float Max_RotateSpeed;
    public float Stopping_Distance;
    public int UpdateModifier = 10;



    /// <summary>
    ///TEST VARIABLES
    /// </summary>
    ///////////////////
    //ORDERS
    public bool MoveTo;
    public bool Patrol;
    public bool Guard;


    ///////////////////

    private void Awake()
    {

        Animator = GetComponent<Animator>();
    }

}