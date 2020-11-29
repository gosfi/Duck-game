using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public List<MenuButton> buttons;
    public bool canUpdateMenu;
    public GameObject Point;
    public int NumberOfButtons;
    private int SelectedButton = 1;
    public List<Transform> buttonPos;

    private void Start()
    {
        canUpdateMenu = false;
    }
    private void OnPlay()
    {
        if (canUpdateMenu)
        {
            if (SelectedButton == 1)
            {
                SceneManager.LoadScene(buttons[0].SceneName);
            }
            else if (SelectedButton == 2)
            {
                Application.Quit();
            }
        }
    }
    private void OnButtonUp()
    {
        if (canUpdateMenu)
        {
            if (SelectedButton > 1)
            {
                SelectedButton -= 1;
            }
            MoveThePointer();
            return;
        }
        // Checks if the pointer needs to move down or up, in this case the poiter moves up one button

    }
    private void OnButtonDown()
    {
        if (canUpdateMenu)
        {
            if (SelectedButton < NumberOfButtons)
            {
                SelectedButton += 1;
            }
            MoveThePointer();
            return;
        }
        // Checks if the pointer needs to move down or up, in this case the poiter moves down one button

    }

    private void MoveThePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            Point.transform.position = buttonPos[0].position;
        }
        else if (SelectedButton == 2)
        {
            Point.transform.position = buttonPos[1].position;
        }
        else if (SelectedButton == 3)
        {
            Point.transform.position = buttonPos[2].position;
        }
        else if (SelectedButton == 4)
        {
            Point.transform.position = buttonPos[3].position;
        }
    }
}
