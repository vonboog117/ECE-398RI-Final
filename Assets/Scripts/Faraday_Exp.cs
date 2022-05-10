using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faraday_Exp : MonoBehaviour
{
    // Start is called before the first frame update
    private float current;
    private float mfield;
    private float velocity;
    private float conductivity;
    private float oldPosition;
    private float currentPosition;
    private float oldTime;
    private float newTime;
    private float startTime;
    private float waitTime;

    public Text efield_Text;
    public Text current_Text;
    public Text mfield_Text;
    //public Text radius_Text;
    public InputField velocity_field;
    public InputField conductivity_field;
    public GameObject Magnet;
    public GameObject Wire;
    public GameObject Equations;


    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        mfield = 0;
        velocity = 0;
        conductivity = 0;
        oldPosition = 0;
        currentPosition = 0;
        oldTime = 0;
        newTime = 0;
        startTime = 0;
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        oldTime = newTime;
        newTime = Time.timeSinceLevelLoad;
        float deltaTime = newTime - oldTime;
        float deltaPos = oldPosition - currentPosition;

        if (velocity_field.text != "" && velocity_field.text != "." && velocity_field.text != "-")
        {
            velocity = float.Parse(velocity_field.text);
        }
        else if(velocity_field.text == "")
        {
            velocity = deltaPos / deltaTime;
            waitTime = Time.timeSinceLevelLoad;
            if (waitTime > startTime + .1)
            {
                oldPosition = currentPosition;
            }
        }
        else
        {
            velocity = 0;
        }

        if (conductivity_field.text != "" && conductivity_field.text != "." && conductivity_field.text != "-")
        {
            conductivity = float.Parse(conductivity_field.text);
        }
        else
        {
            conductivity = 0;
        }

        //float mflux = (float)mfield / (currentPosition + 1);
        float mflux = (float)mfield * velocity;

        if (velocity * mfield > 0)
        {
            Vector3 newScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
            Wire.transform.localScale = newScale;
        }else
        {
            Vector3 newScale = new Vector3((float)0.2, (float)0.2, (float)-0.2);
            Wire.transform.localScale = newScale;
        }

        current = (float)conductivity * (-1)*((float)mflux);
        efield_Text.text = (-1 * mflux).ToString();
        current_Text.text = current.ToString();
        mfield_Text.text = mfield.ToString();
        //Vector3 newEField = new Vector3(rate_of_field_change, rate_of_field_change, rate_of_field_change);
        //EField.transform.localScale = newEField;


        //mfield_Text.text = mfield.ToString();
        //current_Text.text = current.ToString();

    }

    public void ChangeMagnetism(int delta)
    {
        mfield += delta;
    }

    public void ChangePosition(Slider slider) 
    {
        float delta = slider.value;
        oldPosition = currentPosition;
        currentPosition = delta;
        Vector3 oldPos = Magnet.transform.position;
        oldPos.y = delta;
        Magnet.transform.position = oldPos;
        startTime = Time.timeSinceLevelLoad;
    }

    public void Show_Equations(bool show)
    {
        Equations.SetActive(show);
    }
}
