using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {
    public static void GoToMenu(MenuName menuName)
    {
        switch(menuName)
        {
            case MenuName.start:
                SceneManager.LoadScene("GameMenu");
                break;
            case MenuName.pause:
                Object.Instantiate(Resources.Load("Prefabs/PauseMenu"));
                break;
        }
    }
}
