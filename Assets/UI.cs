using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UI : MonoBehaviour
{
    Animator UIAnimator;

    public bool inMenu = false;

    private void Start()
    {
        UIAnimator = GetComponent<Animator>();
        ShowMenu(inMenu);
    }

    public void ShowMenu(bool newState)
    {
        if (newState == UIAnimator.GetBool("Menu Open")) return;

        inMenu = newState;
        UIAnimator.SetBool("Menu Open", newState);
        UIAnimator.SetTrigger("Toggle Menu");
    }

    public void ExitApp()
    {
        Debug.LogWarning("Exiting Game!");
        Application.Quit();
    }
}
