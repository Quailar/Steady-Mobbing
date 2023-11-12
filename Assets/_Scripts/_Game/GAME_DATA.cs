using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class GAME_DATA : MonoBehaviour
{
    //#############################################################################################################################################
    public bool activateDebugger;

    //#############################################################################################################################################
    [Header("=================GAME TIME=================")]
    [SerializeField] public DateTime GAME_DATETIME;
    public string[] SEASONS_IN_YEAR = { "Winter", "Spring", "Summer", "Fall" };
    public string[] DAYS_IN_WEEK = { "Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat" };
    public int[] DAYS_IN_MONTH = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public string[] MONTHS_IN_YEAR = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    //#############################################################################################################################################
    [Header("=================GAME MAP=================")]
    public GameObject GameMap;
    public bool isMapGenerated;

    //#############################################################################################################################################
    [Header("=================TEAMS=================")]
    public string[] TEAM_NAMES = { "Civilian", "Team1", "Team2", "Team3", "Team4", "Police" };
    public Color[] TEAM_COLORS = { Color.white, Color.grey, Color.black, Color.red, Color.green, Color.blue, Color.cyan, Color.magenta, Color.yellow };

    //#############################################################################################################################################
    [Header("=================TEXT=================")]
    public string[] MALE_FIRST_NAMES = { "Alex", "Bernard", "Charles", "Donald", "Edgar", "Felix", "Greg", "Hector", "Ivan", "Jovan", "Kevin", "Lucas", "Morty", "Norman", "Oscar", "Patrick", "Quincey", "Roger", "Ricardo", "Steven", "Theodore", "Ulysis", "Victor", "Winston", "Xavier", "Yuri", "Zeke", };
    public string[] FEMALE_FIRST_NAMES = { "Angie", "Brenda", "Crystal", "Dedra", "Elanore", "Fiona", "Gabriella", "Helen", "Isabelle", "Jackie", "Kristen", "Lori", "Mandy", "Nancy", "Olivia", "Paige", "Quinn", "Rosa", "Rachel", "Stacy", "Tiffany", "Ursa", "Victoria", "Winnie", "Xenia", "Yasmine", "Zoe", };
    public string[] LAST_NAMES = { "Abney", "Bachman", "Cranfield", "Dearborn", "Etheridge", "Figgins", "Guthman", "Hutchinson", "Iverson", "Jenkins", "Kellogg", "Lazowski", "MacFarlane", "Newbury", "O’Brien", "Peabody", "Quayle", "Ravitz", "Sadler", "Taggart", "Ulbricht", "Varney", "Wagnon", "Xenos", "Yarborough", "Zalewski", };
    public string[] MALE_NICK_NAMES = { "Banana", "Butters", "Sausage", "Mandingo", "Twitch", "Butters", "Fingers", "Lucky", "Professor", "Bubbles", "Pistol", "Cheech", "Cadillac", "Money", "Snake", "Ice", "Laser", "Stickman", "Lips", "Widow Maker", "Tiny", "Black Widow", "Baby Face", "Mustach", "Speedy", "Sneaky", "King", "Queen", "Greese", "Slick", "Serge", "Captain", "Green Horn", "Woodchuck", "Tiger", "Cockroach", "Noodles", "Uncle", "Rosco", "Ninja", "Ancient", "Undertaker", "Cabbie", "Dusty", "Ashy", "Twinkles", "Snitch", "Weasel" };
    public string[] FEMALE_NICK_NAMES = { "Bubbles", "Cheech", "Money", "Ice", "Lips", "Widow Maker", "Tiny", "Black Widow", "Wiskers", "Speedy", "Sneaky", "Queen", "Greese", "Slick", "Captain", "Green Horn", "Woodchuck", "Tiger", "Cabbie", "Stinky", "Twinkles", "Hoover", "Snitch", "Rainbow", "Glitter", "Bombshell", "Jugs", "Chopper", "Bobit", "Jewels", "Diamond", "Pearls", "Ruby" };
    public string[] PROFESSIONS = { "Celebrity", "Fisherman", "Engineer", "Mechanic", "Dentist", "Farmer", "Supervisor", "Counselor", "Doctor", "Actor", "Zoo Keeper", "Investigator", "Broker", "Teacher", "Student", "Pilot", "Barber", "Bartender", "Baker", "Construction", "Chiropractor", "Clergy", "Game Designer", "Dancer", "Driller", "RuffNeck", "Fire Fighter", "Scientist", "Pool Shark", "Athlete", "Farmer", "Janitor", "Jeweler", "Investor", "Clerk", "Taxi Driver", "Taylor", "Worker", "Dog Walker", "Mechanic", "Taxi Driver", "Tax Agent", "Stock Borker", "Importer", "Corrections", "Waste Maanagement", "Journalist", "Artist" };
    public string[] UNIT_ORDERS = { "GoTo: ", "Patrol: ", "Guard: " };
    public string[] MOODS = { "Bad", "Poor", "Neutral", "Good", "Excellent" };

    //#############################################################################################################################################
    public string[] GOVERNMENT_BUILDING_NAMES = { "Hospital", "Police Station", "City Hall", "College", "High School" };
    public string[] RESIDENTIAL_FIRST_NAME = { "Langly", "Hummingbird", "Mustang", "Dragon", "Tenement", "Lilly", "Pelican", "Sparrow", "Eagle", "Paragon", "Strawberry", "Peach", "Citrus", "Candy", "Ether", "Freedom", "Acme", "Corporate", "Government", "Lavendar", "Donkey", "Slummers", "Chaos", "Rose", "Canary", "Inner", "Outter", "Private", "French", "Port", "Upper", "Lower", "North", "South", "East", "West", "Tiger" };
    public string[] RESIDENTIAL_LAST_NAME = { "Heights", "Abby", "Bay", "Projects", "Slums", "Lands", "Lakes", "Valley", "Hills", "Manor", "Flats", "Peaks", "Estates", "View", "Cove", "Basin", "Bend", "Gardens", "Shores", "Point", "Square", "Circle", "Harbor", "Docks", "Ridge", "Park", "Groves", "Meadows", "Shire", "Palms", "Corner", "Quarters", "Canyon", "Gourge", "Port", "Island" };
    public string[] COMMERCIAL_BUSINESS_NAMES = { "Warehouse", "Storage", "Pawn Shop", "Accounting", "Plumbing", "Plumbing", "Temple", "Computer Repair", "Retail Store", "Grocery Store", "Meat Market", "Skating Ring", "Day Spa", "Music Store", "Tax Agency", "Real Estate", "Plumbing", "Plumbing", "Plumbing", "Insurance Company", "Clothing Store", "Dentist", "Pizza Store", "Restaurant", "Flower Store", "Auto Repair", "Tire Shop", "Candy Store", "Coffee Shop", "Gun Store", "Furniture Store", "Gas Station", "Party Planners", "Staffing Agency", "Sporting Goods", "Marketing Agency", "Arts & Hobbies", "Arcade", "Liquor Store", "Tools Store", };
    public string[] INDUSTRIAL_BUSINESS_NAMES = { "Warehouse", "Storage", "Manufactoring", "Recycling", "Coal Processing", "Lumber Mill", "Quary", "Refinery", "Smelting", "Steal PRocessing", "Chemical Plant", "Power Station", "Bottling Plant", "Paper Mill", "Chicken Farm" };
    public string[] ILLLEGAL_BUSINESS_NAMES = { "Fight Club", "Cock Fighting", "Dog Fighting", "Brothel", "Moonshine", "Brewery", "Guns", "Chop Shop", "Drug Lab", "Casino", "Porn Studio" };
    public string[] CRIMINAL_RECORD_NAMES = { "Assault", "PickPocket", "AutoTheft", "Vandalism", "Stabbing", "Murder", "Arson", "Trafficking", "Prostitution", "Kidnapping" };
    public string[] AUTO_MODEL_NAMES = { "Cougar", "Rambler", "Lazer", "Pinto", "Vesica", "Viking", "Raptor", "Victorian", "Bronco", "Zinger", "Paddy Wagon", "Dingo", "Zeta", "" };


    //#############################################################################################################################################
    [Header("=================PREFABS=================")]
    [SerializeField] public List<GameObject> PREFAB_UNITS_LIST = new List<GameObject>();
    [SerializeField] public List<GameObject> PREFAB_BUILDING_BLOCK_LIST = new List<GameObject>();

    public GameObject PREFAB_HOVER_DISPLAY;

    //#############################################################################################################################################
    [Header("=================REGISTERED UNITS=================")]
    [SerializeField] public List<Unit> RegisteredUnits = new List<Unit>();
    [SerializeField] public List<Building> RegisteredBuildings = new List<Building>();
    // [SerializeField] public List<Business> RegisteredBusiness = new List<Business>();

    //#############################################################################################################################################
    [SerializeField] public List<GameObject> CivilianUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> Team1Units = new List<GameObject>();
    [SerializeField] public List<GameObject> Team2Units = new List<GameObject>();
    [SerializeField] public List<GameObject> Team3Units = new List<GameObject>();
    [SerializeField] public List<GameObject> Team4Units = new List<GameObject>();
    [SerializeField] public List<GameObject> PoliceUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> GangsterUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> ExtraUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> AccountantUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> LawyerUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> JudgeUnits = new List<GameObject>();
    [SerializeField] public List<GameObject> ManagerUnits = new List<GameObject>();
    //#############################################################################################################################################

    [SerializeField] public List<GameObject> Residential_Building_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Commercial_Building_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Industrial_Building_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Residential_Zone_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Commercial_Zone_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Industrial_Zone_List = new List<GameObject>();
    [SerializeField] public List<GameObject> Neighborhood_List = new List<GameObject>();
    //#############################################################################################################################################


    [SerializeField] public List<GameObject> Building_Entrance_List = new List<GameObject>();

    //#############################################################################################################################################


}
