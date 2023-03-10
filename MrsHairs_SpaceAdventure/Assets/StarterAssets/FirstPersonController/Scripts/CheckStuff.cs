using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStuff : MonoBehaviour
{
    private bool ison = false;
    public void IsActive(GameObject objecto)
    {
        if (objecto.activeSelf && ison)
        {
            objecto.SetActive(false);
            ison = false;
        }
        else if (!objecto.activeSelf && !ison)
        {
            objecto.SetActive(true);
            ison = true;
        }

    }
}
