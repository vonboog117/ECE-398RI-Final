using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unnamed_Exp : MonoBehaviour
{
    public GameObject Equations;   

    public void Show_Equations(bool show)
    {
        Equations.SetActive(show);
    }
}
