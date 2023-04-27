using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

//Defines the main menu (Does not inherit Menu)

public class MainMenu : MonoBehaviour
{
    bool saveDataLoaded;
    public Canvas menu;
    bool startingGame;

    [SerializeField] private List<GameObject> submenus;
    int activeSubmenu;

    [HideInInspector] public bool canInteract;

    void Start()
    {   
        startingGame = false;

        foreach(GameObject submenu in submenus) submenu.SetActive(false);
        activeSubmenu = 0;
        submenus[activeSubmenu].SetActive(true);

        saveDataLoaded = false;

        canInteract = true;

        LoadSaveData();
    }

    public void LoadSaveData()
    {
        saveDataLoaded = true;
    }

    public void OnDeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }

}
