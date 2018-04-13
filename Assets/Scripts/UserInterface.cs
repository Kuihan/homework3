using UnityEngine;
using System.Collections;
using Com.Mygame;

public class UserInterface : MonoBehaviour
{

    GameSceneController scene;
    IQueryGameStatus state;
    IUserActions action;

    float width, height;

    float castw(float scale)
    {
        return (Screen.width - width) / scale;
    }

    float casth(float scale)
    {
        return (Screen.height - height) / scale;
    }

    void Start()
    {
        scene = GameSceneController.GetInstance();
        state = GameSceneController.GetInstance() as IQueryGameStatus;
        action = GameSceneController.GetInstance() as IUserActions;
    }

    void OnGUI()
    {
        width = Screen.width / 12;
        height = Screen.height / 12;

        string message = state.isMessage();
        if (message != "")
        {
            if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), message))
            {
                action.restart();
            }
        }
        else
        {
            if (!state.isMoving())
            {
                if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), "Go"))
                {
                    action.moveBoat();
                }
                if (GUI.Button(new Rect(castw(10.5f), casth(4f), width, height), "On"))
                {
                    action.devilSOnB();
                }
                if (GUI.Button(new Rect(castw(4.3f), casth(4f), width, height), "On"))
                {
                    action.priestSOnB();
                }
                if (GUI.Button(new Rect(castw(1.1f), casth(4f), width, height), "On"))
                {
                    action.devilEOnB();
                }
                if (GUI.Button(new Rect(castw(1.3f), casth(4f), width, height), "On"))
                {
                    action.priestEOnB();
                }
                if (GUI.Button(new Rect(castw(2.5f), casth(1.3f), width, height), "Off"))
                {
                    action.offBoatL();
                }
                if (GUI.Button(new Rect(castw(1.7f), casth(1.3f), width, height), "Off"))
                {
                    action.offBoatR();
                }
            }
        }
    }
}