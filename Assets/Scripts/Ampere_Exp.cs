using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ampere_Exp : MonoBehaviour
{
    private int current;
    private double mfield;
    private float radius;
    private float rate_of_field_change;

    public Text mfield_Text;
    public Text current_Text;
    //public Text radius_Text;
    public InputField radius_field;
    public InputField efield_field;
    public GameObject MField;
    public GameObject EField;
    public GameObject Current_Arrow;
    public GameObject Equations;


    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        mfield = 0.0;
        radius = 0;
        rate_of_field_change = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (radius_field.text != "" && radius_field.text != "." && radius_field.text != "-")
        {
            radius = float.Parse(radius_field.text);
        }else
        {
            radius = 0;
        }
        

        if (efield_field.text != "" && efield_field.text != "." && efield_field.text != "-")
        {
            rate_of_field_change = float.Parse(efield_field.text);
        }
        else
        {
            rate_of_field_change = 0;
        }
        //Vector3 newEField = new Vector3(rate_of_field_change, rate_of_field_change, rate_of_field_change);
        //EField.transform.localScale = newEField;

        mfield = (current*radius) + rate_of_field_change;
        if (mfield > 0)
        {
            Vector3 newRadius = new Vector3((float)(-0.125) * radius, (float)(0.125) * radius, (float)(0.125) * radius);
            MField.transform.localScale = newRadius;
        }
        else
        {
            Vector3 newRadius = new Vector3((float)(-0.125) * radius, (float)(0.125) * radius, (float)(-0.125) * radius);
            MField.transform.localScale = newRadius;
        }

        mfield_Text.text = mfield.ToString();
        current_Text.text = current.ToString();

    }

    public void ChangeCurrent(int delta)
    {
        current += delta;
        float scaledCurrent = (float)0.1 * current;
        Vector3 newScale = new Vector3((float)0.1, (float)0.1, (-1)*scaledCurrent);
        Current_Arrow.transform.localScale = newScale;
    }

    public void Show_Equations(bool show)
    {
        Equations.SetActive(show);
    }
}
