using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Consts.currentMenu = MenuName.start;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            Consts.currentMenu = MenuName.game;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

    public void HandleStartButtonOnClick()
    {
        Debug.Log("start pressed!");
    }
    public void HandleMenuButtonOnClick()
    {
        Debug.Log("menu pressed!");
    }
}
