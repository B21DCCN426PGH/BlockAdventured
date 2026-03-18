using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static Action<bool> GameOver;

    public static Action<int> AddScores;

    public static Action CheckIfShapeCanBePlaced;

    public static Action MoveShapeToStartPotition;

    public static Action RequestNewShapes;

    public static Action SetShapeInative;

    public static Action<int, int> UpdateBestScoreBar;

    public static Action<Config.SquareColor> UpdateSquareColor;

    public static Action ShowCongratulationWritings;

    public static Action<Config.SquareColor> ShowBonusScreen;
}
 