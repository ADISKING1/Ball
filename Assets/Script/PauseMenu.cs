using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Consts.currentMenu = MenuName.pause;
    }

    public void HandleResumeButtonOnClick()
    {
        Time.timeScale = 1;
        Consts.currentMenu = MenuName.game;
        Destroy(gameObject);
    }
    public void HandleStartMenuButtonOnClick()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.start);
        Destroy(gameObject);
    }
}
