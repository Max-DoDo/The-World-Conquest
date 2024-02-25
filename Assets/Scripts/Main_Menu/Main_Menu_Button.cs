using UnityEngine;
/// <summary>
///     Event Method called by Button in Main Menu
/// </summary>
/// <author>
///     Max Wang
/// </author>
public class Main_Menu_Button : MonoBehaviour
{

/// <summary>
///     New Game Button method.
/// </summary>
    public void New_Game_Button_Event(){
        Debug.Log("New_Game_Button_Event");
    }

/// <summary>
///     Load Game Button method.
/// </summary>
    public void Load_Game_Button_Event(){
        Debug.Log("Load_Game_Button_Event");
    }

/// <summary>
///     Setting Button Event Method.
/// </summary>
    public void Setting_Button_Event(){
        Debug.Log("Setting_Button_Event");
    }

/// <summary>
///     Exit Button method.
/// </summary>
    public void Exit_Button_Event(){
        //exit
        Debug.Log("Exit_Button_Event");
        Application.Quit();
    }
}
