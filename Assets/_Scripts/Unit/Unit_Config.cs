using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Unit_Config : MonoBehaviour
{
    GAME_DATA Game_Data;

    public bool FirstRun;
    [SerializeField] public Unit Unit;
    //[SerializeField] public NavMeshAgent Agent;
    public int speedModifier = 1;
    public float stoppingDistance = .05f;
    public int rotateSpeed = 10;

    void Awake()
    {
        Game_Data = GameObject.FindGameObjectWithTag("GAMEDATA").GetComponent<GAME_DATA>();
        Unit = GetComponent<Unit>();

    }

    private void Start()
    {


    }


    private void Update()
    {

        if (Game_Data.isMapGenerated)
        {
            if (!FirstRun)
            {
                ConfigureUnit();
                FirstRun = true;
            }

        }
    }


    private void ConfigureUnit()
    {
        RegisterUnit(Unit.Unit_Class.GetHashCode());
        SetBio();

        int i = Random.Range(0, 1);//Gender
        GenerateGender(i);
        GenerateBody(i);

        GenerateName(i);
        GenerateProfession(Unit.Unit_Class.GetHashCode());

        SetHomeAndWork();
        SetVitals();
        SetStats();
        SetDiplomacy();
        SetNavigation();


        if (Game_Data.activateDebugger)
        {
            print("Unit Online: " + Unit.First_Name + " '" + Unit.Nick_Name + "' " + Unit.Last_Name);
        }
    }

    private void RegisterUnit(int _type)
    {
        Unit.ID = Math.Abs(Unit.GetInstanceID());
        Unit.Instance = Unit;
        Game_Data.RegisteredUnits.Add(Unit);
        switch (_type)
        {
            case 6:
                Game_Data.JudgeUnits.Add(Unit.GameObject());
                break;
            case 5:
                Game_Data.LawyerUnits.Add(Unit.GameObject());
                break;
            case 4:
                Game_Data.AccountantUnits.Add(Unit.GameObject());
                break;
            case 3:
                Game_Data.ManagerUnits.Add(Unit.GameObject());
                break;
            case 2:
                Game_Data.PoliceUnits.Add(Unit.GameObject());
                break;
            case 1:
                Game_Data.GangsterUnits.Add(Unit.GameObject());
                break;
            case 0:
                Game_Data.CivilianUnits.Add(Unit.GameObject());
                break;
            default:
                Game_Data.CivilianUnits.Add(Unit.GameObject());
                break;
        }

    }

    private void SetBio()
    {
        Unit.Mood = Game_Data.MOODS[2];
        Unit.Age = Random.Range(18, 60);
        Unit.Cost_To_Hire = Random.Range(50, 250);
        Unit.Cash = Random.Range(0, 100);
    }




    void GenerateGender(int gend)
    {
        switch (gend)
        {
            case 1:
                Unit.Gender = "F";
                break;
            case 0:
                Unit.Gender = "M";
                break;
        }
    }

    void GenerateBody(int gend)
    {
        ClearBody();
        switch (gend)
        {
            case 1:
                Unit.Head = Random.Range(0, Unit._FHeads.Count);
                Unit.Body = Random.Range(0, Unit._FBodys.Count);

                Unit.Animator.runtimeAnimatorController = Unit.Animation_Controllers[1];
                Unit.Animator.avatar = Unit.Avatars[1];

                Unit._FHeads[Unit.Head].SetActive(true);
                Unit._FBodys[Unit.Body].SetActive(true);
                break;
            case 0:
                Unit.Head = Random.Range(0, Unit._MHeads.Count);
                Unit.Body = Random.Range(0, Unit._MBodys.Count);

                Unit.Animator.runtimeAnimatorController = Unit.Animation_Controllers[0];
                Unit.Animator.avatar = Unit.Avatars[0];

                Unit._MHeads[Unit.Head].SetActive(true);
                Unit._MBodys[Unit.Body].SetActive(true);
                break;
        }
    }

    private void ClearBody()
    {
        for (int i = 0; i < Unit._MHeads.Count; i++)
        {
            if (Unit._MHeads[i].activeSelf == true)
            {
                Unit._MHeads[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._MGlasses.Count; i++)
        {
            if (Unit._MGlasses[i].activeSelf == true)
            {
                Unit._MGlasses[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._MBodys.Count; i++)
        {
            if (Unit._MBodys[i].activeSelf == true)
            {
                Unit._MBodys[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._MWeapons.Count; i++)
        {
            if (Unit._MWeapons[i].activeSelf == true)
            {
                Unit._MWeapons[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._FHeads.Count; i++)
        {
            if (Unit._FHeads[i].activeSelf == true)
            {
                Unit._FHeads[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._FGlasses.Count; i++)
        {
            if (Unit._FGlasses[i].activeSelf == true)
            {
                Unit._FGlasses[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._FBodys.Count; i++)
        {
            if (Unit._FBodys[i].activeSelf == true)
            {
                Unit._FBodys[i].SetActive(false);
            }
        }
        for (int i = 0; i < Unit._FWeapons.Count; i++)
        {
            if (Unit._FWeapons[i].activeSelf == true)
            {
                Unit._FWeapons[i].SetActive(false);
            }
        }
    }

    void GenerateName(int gend)
    {

        switch (gend)
        {
            case 1:
                int _fn = Random.Range(0, Game_Data.FEMALE_FIRST_NAMES.Length);
                Unit.First_Name = Game_Data.FEMALE_FIRST_NAMES[_fn];

                int _nn = Random.Range(0, Game_Data.FEMALE_NICK_NAMES.Length);
                Unit.Nick_Name = Game_Data.FEMALE_NICK_NAMES[_nn];
                break;
            case 0:
                _fn = Random.Range(0, Game_Data.MALE_FIRST_NAMES.Length);
                Unit.First_Name = Game_Data.MALE_FIRST_NAMES[_fn];

                _nn = Random.Range(0, Game_Data.MALE_NICK_NAMES.Length);
                Unit.Nick_Name = Game_Data.MALE_NICK_NAMES[_nn];
                break;
            default:
                _fn = Random.Range(0, Game_Data.MALE_FIRST_NAMES.Length);
                Unit.First_Name = Game_Data.MALE_FIRST_NAMES[_fn];

                _nn = Random.Range(0, Game_Data.MALE_NICK_NAMES.Length);
                Unit.Nick_Name = Game_Data.MALE_NICK_NAMES[_nn];
                break;
        }
        int _ln = Random.Range(0, Game_Data.LAST_NAMES.Length);
        Unit.Last_Name = Game_Data.LAST_NAMES[_ln];
    }
    void GenerateProfession(int unitClass)
    {
        //Civilian, Gangster, Police, Manager, Accountant, Lawyer, Judge, Specialty
        switch (unitClass)
        {
            case 7:
                Unit.Profession = "Specialty";
                break;
            case 6:
                Unit.Profession = "Judge";
                break;
            case 5:
                Unit.Profession = "Lawyer";
                break;
            case 4:
                Unit.Profession = "Accountant";
                break;
            case 3:
                Unit.Profession = "Manager";
                break;
            case 2:
                Unit.Profession = "Police";
                break;
            case 1:
                Unit.Profession = "Gangster";
                break;
            case 0:
                int i = Random.Range(0, Game_Data.PROFESSIONS.Length);
                Unit.Profession = Game_Data.PROFESSIONS[i];
                break;
            default:
                i = Random.Range(0, Game_Data.PROFESSIONS.Length);
                Unit.Profession = Game_Data.PROFESSIONS[i];
                break;
        }

    }
    private void SetNavigation()
    {
        Unit.Stopping_Distance = stoppingDistance;
        Unit.Max_MoveSpeed = (Unit.Speed / 10 + 1) * speedModifier;
        Unit.Max_RotateSpeed = rotateSpeed;
    }

    void SetHomeAndWork()
    {
        int i = Random.Range(0, Game_Data.Residential_Building_List.Count);
        Unit.Residence = Game_Data.Residential_Building_List[i];
        i = Random.Range(0, Game_Data.Commercial_Building_List.Count);
        Unit.Workplace = Game_Data.Commercial_Building_List[i];
    }

    private void SetVitals()
    {
        Unit.Max_HitPoints = Random.Range(80, 120);
        Unit.Current_HitPoints = Unit.Max_HitPoints;
        Unit.IsAlive = true;
        Unit.IsHospitalized = false;
        Unit.TimeLeftInHospital = 0;
        Unit.IsTraining = false;
        Unit.TimeLeftInTraining = 0;
        Unit.IsBleeding = false;
        Unit.IsInjured = false;
        Unit.Time_Till_Death = 0;
        Unit.IsBusy = false;
        Unit.IsDriving = false;
        Unit.IsUnderAttack = false;
        Unit.IsBeating = false;
        Unit.IsStabbing = false;
        Unit.IsShooting = false;
        Unit.IsFleeing = false;
    }

    private void SetStats()
    {
        Unit.Strength = Random.Range(1, 10);
        Unit.Intelligence = Random.Range(1, 10);
        Unit.Dexterity = Random.Range(1, 10);
        Unit.Vision = Random.Range(1, 10);
        Unit.Aim = Random.Range(1, 10);
        Unit.Speed = 5;//Random.Range(1, 10);
        Unit.Driving = Random.Range(1, 10);
        Unit.Stealth = Random.Range(1, 10);
        Unit.Total_Stats = Unit.Strength + Unit.Intelligence + Unit.Dexterity + Unit.Vision + Unit.Aim + Unit.Speed + Unit.Driving + Unit.Stealth;
    }

    private void SetDiplomacy()
    {
        Unit.Team = Game_Data.TEAM_NAMES[0];
        Unit.IsLieutenant = false;
        //AddSquadMembers=GameObject unit;
        //RemoveSquadMembers=GameObject unit;
        Unit.Wanted_Level = 0;
        Unit.IsJailed = false;
        Unit.Time_Left_InJail = 0;
    }


}