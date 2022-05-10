using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauss_Exp : MonoBehaviour
{
    private int current_surface;
    private double displacement;
    private float radius;
    private int charge;

    public Text displacement_Text;
    public Text charge_Text;
    //public Text radius_Text;
    public InputField radius_field;
    public GameObject Gaussian_Sphere;
    public GameObject Gaussian_Cube;
    public GameObject Equations;

    // Start is called before the first frame update
    void Start()
    {
        current_surface = 0;
        displacement = 0.0;
        radius = 0;
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (radius_field.text != "" && radius_field.text != ".") 
        {
            radius = float.Parse(radius_field.text);
        }
        else
        {
            radius = 0;
        }
        Vector3 newScale = new Vector3(radius, radius, radius);
        Gaussian_Sphere.transform.localScale = newScale;
        //radius_Text.text = radius.ToString();

        if (current_surface == 0) //No active surface
        {
            displacement_Text.text = "0";
        } else if (current_surface == 1) //Sphere
        {
            if (radius < 1)
            {
                displacement = 0.0;
            }
            else
            {
                displacement = charge;
            }

            displacement_Text.text = displacement.ToString();
        } else if (current_surface == 2) 
        {
            displacement = (charge / 2.0);

            displacement_Text.text = displacement.ToString();
        }
        charge_Text.text = charge.ToString();

    }

    public void ChangeSurface(int s)
    {
        current_surface = s;
        if (s == 1) { //Sphere
            Gaussian_Cube.SetActive(false);

            Gaussian_Sphere.SetActive(true);
            //Vector3 newScale = new Vector3(radius, radius, radius);
            //Gaussian_Sphere.transform.localScale = newScale;

        }
        else if (s == 2) { //Rectangular Prism
            Gaussian_Sphere.SetActive(false);
            Gaussian_Cube.SetActive(true);
        }
    }

    public void ChangeCharge(int delta) {
        charge += delta;
    }

    public void Show_Equations(bool show)
    {
        Equations.SetActive(show);
    }
}
