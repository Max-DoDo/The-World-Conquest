using System;
using System.Collections.Generic;
using UnityEngine;

public class AI_Core : MonoBehaviour
{
    private Player[] players;
    private Country[] countries;

    void Start()
    {
        // 初始化玩家和国家列表
        players = FindObjectsOfType<Player>();
        countries = FindObjectsOfType<Country>();
        SetTroop();
    }

    private void SetTroop()
    {
        foreach (Player player in players)
        {
            if (player.IsAI())
            {
                AISetTroop(player);
            }
        }
    }

    private void AISetTroop(Player aiPlayer)
    {
        // 获取当前 AI 玩家控制的国家列表
        List<Country> controlledCountries = aiPlayer.GetControlledCountries();

        // 计算 AI 玩家新回合得到的军队数量
        int newTroops = CalculateNewTroops(aiPlayer);

        // 分配军队数量到各个国家
        foreach (Country country in controlledCountries)
        {
            country.army += newTroops;

            // 判断是否攻击邻近的敌对国家
            if (ShouldAttack(country))
            {
                AttackNeighboringCountry(country);
            }
        }
    }

    private int CalculateNewTroops(Player player)
    {
        // 这里可以根据游戏规则和玩家控制的国家数量来计算新回合得到的军队数量
        // 这里只是一个简单的示例，假设每个玩家控制的国家数量除以2就是新回合得到的军队数量
        int troopsPerCountry = player.GetControlledCountries().Count / 2;
        return troopsPerCountry;
    }

    private bool ShouldAttack(Country country)
    {
        // 判断是否攻击邻近的敌对国家的逻辑
        // 这里可以根据自己的游戏规则来实现
        // 例如，判断是否有邻近的敌对国家，以及成功率是否超过50%
        // 这里只是一个简单的示例，假设只有在邻近国家有敌对国家且成功率超过50%时才攻击
        foreach (Country neighbor in GetNeighbors(country))
        {
            if (neighbor.currentPlayer != country.currentPlayer && CalculateSuccessRate(country, neighbor) > 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    private float CalculateSuccessRate(Country attacker, Country defender)
    {
        /* 
         * 成功率计算，目前不考虑被反攻，仅考虑成功率
         */
       
        {
            //这里selectCountry()没搞完，是代餐
            // 进攻方骰子数目
            int attackDiceCount = attacker.army > 3 ? 3 : attacker.army - 1;
            // 防守方骰子数目
            int defenseDiceCount = defender.army > 2 ? 2 : defender.army;
            //************************************************
            // 初始化成功计数和大成功计数
            float successCount = 0;
            float bigSuccessCount = 0;

            // 遍历所有可能的骰子点数组合
            for (int attackDice = 1; attackDice <= 6; attackDice++)
            {
                for (int defenseDice = 1; defenseDice <= 6; defenseDice++)
                {
                    // 计算进攻方和防守方的最大点数
                    int maxAttackDice = Math.Min(attackDiceCount, attackDice);
                    int maxDefenseDice = Math.Min(defenseDiceCount, defenseDice);

                    // 如果进攻方至少有一个骰子的点数大于防守方的至少一个骰子的点数，则增加成功计数
                    if (maxAttackDice > maxDefenseDice)
                    {
                        successCount += 1;
                        // 如果进攻方的最大点数大于防守方的最大点数，并且至少有一个骰子的点数大于防守方的最大点数，则增加大成功计数
                        if (attackDice > defenseDice)
                        {
                            bigSuccessCount += 1;
                        }
                    }
                }
            }

            // 计算成功率和大成功率
            float successRate = successCount / 36;
            float bigSuccessRate = bigSuccessCount / 36;

            // 计算综合成功率
            float compositeSuccessRate = 0.8f * successRate + 0.2f * bigSuccessRate;

            return compositeSuccessRate;
        }

    }

    private void AttackNeighboringCountry(Country country)
    {
        // 攻击邻近的敌对国家的逻辑
        // 这里可以根据游戏规则和攻击成功率来决定战斗结果
        // 这里只是一个简单的示例，假设攻击成功率超过50%时，攻击成功
        foreach (Country neighbor in GetNeighbors(country))
        {
            if (neighbor.currentPlayer != country.currentPlayer && CalculateSuccessRate(country, neighbor) > 0.5f)
            {
                // 攻击成功，更新国家的控制者和军队数量等信息
                neighbor.currentPlayer = country.currentPlayer;
                neighbor.army = country.army - 1; // 假设攻击后剩余一个军队
            }
        }
    }

    private List<Country> GetNeighbors(Country selectedCountry)
    {
        List<Country> neighbors = new List<Country>();
        if (Country.mapData.ContainsKey(selectedCountry.name))
        {
            List<string> neighborNames = Country.mapData[selectedCountry.name];
            foreach (string neighborName in neighborNames)
            {
                // 在 countries 数组中查找相邻国家并添加到列表中
                Country neighbor = Array.Find(countries, c => c.name == neighborName);
                if (neighbor != null)
                {
                    neighbors.Add(neighbor);
                }
            }
        }
        return neighbors;
    }
}