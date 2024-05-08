using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public void HideButton()
    {
        gameObject.SetActive(false);
    }

    public void ShowBtn()
    {
        gameObject.SetActive(true);
    }
}
