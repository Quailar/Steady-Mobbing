using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Highlight : MonoBehaviour
{

    public Unit unit;
    public GameObject HoverDisplay;

    private void Awake()
    {
        unit = GetComponent<Unit>();

    }


    private void OnMouseEnter()
    {


        Debug.Log("Mouse Hover Highlight ");
        HoverDisplay.SetActive(true);

    }


    private void OnMouseExit()
    {
        HoverDisplay.SetActive(false);
    }
}
