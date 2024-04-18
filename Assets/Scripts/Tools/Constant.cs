using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{
    private Constant(){}

    public const int GAMEMODE_SINGLEPLAYER = 1;
    public const int GAMEMODE_MUTIPLAYER = 2;
    public const int GAMEMODE_SETTROOP = 4;
    public const int GAMEMODE_SWITCHCARDS = 8;
    public const int GAMEMODE_ATTACK = 16;
    public const int GAMEMODE_MOVEMENT = 32;
    public const int GAMEMODE_DEFENSE = 64;

    public const int CONTINENT_ASIA = 1;
    public const int CONTINENT_AFRICA = 2;
    public const int CONTINENT_EUROPE = 3;
    public const int CONTINENT_NORTH_AMERICA = 4;
    public const int CONTINENT_SOUTH_AMERICA = 5;
    public const int CONTINENT_AUSTRALIA = 6;

    public static Color32 PLAYER1_COLOR = new Color32(238, 63, 77, 255); //茶花红 Tea flower red
    public static Color32 PLAYER2_COLOR = new Color32(21, 85, 154, 255); //海涛蓝 Ocean wave blue
    public static Color32 PLAYER3_COLOR = new Color32(27, 167, 132, 255); //竹绿 banboo green
    // public static Color32 PLAYER4_COLOR = new Color32(186, 207, 101, 255); // 苹果绿 Apple green
    // public static Color32 PLAYER5_COLOR = new Color32(251, 218, 65, 255); //油菜花黄 rapeseed yellow
    public static Color32 PLAYER6_COLOR = new Color32(180, 169, 146, 255); //百灵鸟灰 lark gray
    public static Color32 PLAYER7_COLOR = new Color32(249, 125, 28, 255); //橘橙 orange
    public static Color32 PLAYER8_COLOR = new Color32(129, 60, 133, 255); // 橘梗紫 orange stalk purple

    public static Color32[] PLAYER_COLORS = new Color32[]
    {
        PLAYER1_COLOR,
        PLAYER2_COLOR,
        PLAYER3_COLOR,
        // PLAYER4_COLOR,
        // PLAYER5_COLOR,
        PLAYER6_COLOR,
        PLAYER7_COLOR,
        PLAYER8_COLOR
    };
}
