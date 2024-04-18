// using System;
// using System.Collections.Generic;
// using UnityEngine;

// public class AI_Core : MonoBehaviour
// {
//     private Player[] players;
//     private Country[] countries;

//     void Start()
//     {
//         // ��ʼ����Һ͹����б�
//         players = FindObjectsOfType<Player>();
//         countries = FindObjectsOfType<Country>();
//         SetTroop();
//     }

//     private void SetTroop()
//     {
//         foreach (Player player in players)
//         {
//             if (player.IsAI())
//             {
//                 AISetTroop(player);
//             }
//         }
//     }

//     private void AISetTroop(Player aiPlayer)
//     {
//         // ��ȡ��ǰ AI ��ҿ��ƵĹ����б�
//         List<Country> controlledCountries = aiPlayer.GetControlledCountries();

//         // ���� AI ����»غϵõ��ľ�������
//         int newTroops = CalculateNewTroops(aiPlayer);

//         // ���������������������
//         foreach (Country country in controlledCountries)
//         {
//             country.army += newTroops;

//             // �ж��Ƿ񹥻��ڽ��ĵжԹ���
//             if (ShouldAttack(country))
//             {
//                 AttackNeighboringCountry(country);
//             }
//         }
//     }

//     private int CalculateNewTroops(Player player)
//     {
//         // ������Ը�����Ϸ�������ҿ��ƵĹ��������������»غϵõ��ľ�������
//         // ����ֻ��һ���򵥵�ʾ��������ÿ����ҿ��ƵĹ�����������2�����»غϵõ��ľ�������
//         int troopsPerCountry = player.GetControlledCountries().Count / 2;
//         return troopsPerCountry;
//     }

//     private bool ShouldAttack(Country country)
//     {
//         // �ж��Ƿ񹥻��ڽ��ĵжԹ��ҵ��߼�
//         // ������Ը����Լ�����Ϸ������ʵ��
//         // ���磬�ж��Ƿ����ڽ��ĵжԹ��ң��Լ��ɹ����Ƿ񳬹�50%
//         // ����ֻ��һ���򵥵�ʾ��������ֻ�����ڽ������ежԹ����ҳɹ��ʳ���50%ʱ�Ź���
//         foreach (Country neighbor in GetNeighbors(country))
//         {
//             if (neighbor.currentPlayer != country.currentPlayer && CalculateSuccessRate(country, neighbor) > 0.5f)
//             {
//                 return true;
//             }
//         }
//         return false;
//     }

//     private float CalculateSuccessRate(Country attacker, Country defender)
//     {
//         /* 
//          * �ɹ��ʼ��㣬Ŀǰ�����Ǳ������������ǳɹ���
//          */
       
//         {
//             //����selectCountry()û���꣬�Ǵ���
//             // ������������Ŀ
//             int attackDiceCount = attacker.army > 3 ? 3 : attacker.army - 1;
//             // ���ط�������Ŀ
//             int defenseDiceCount = defender.army > 2 ? 2 : defender.army;
//             //************************************************
//             // ��ʼ���ɹ������ʹ�ɹ�����
//             float successCount = 0;
//             float bigSuccessCount = 0;

//             // �������п��ܵ����ӵ������
//             for (int attackDice = 1; attackDice <= 6; attackDice++)
//             {
//                 for (int defenseDice = 1; defenseDice <= 6; defenseDice++)
//                 {
//                     // ����������ͷ��ط���������
//                     int maxAttackDice = Math.Min(attackDiceCount, attackDice);
//                     int maxDefenseDice = Math.Min(defenseDiceCount, defenseDice);

//                     // ���������������һ�����ӵĵ������ڷ��ط�������һ�����ӵĵ����������ӳɹ�����
//                     if (maxAttackDice > maxDefenseDice)
//                     {
//                         successCount += 1;
//                         // ��������������������ڷ��ط���������������������һ�����ӵĵ������ڷ��ط����������������Ӵ�ɹ�����
//                         if (attackDice > defenseDice)
//                         {
//                             bigSuccessCount += 1;
//                         }
//                     }
//                 }
//             }

//             // ����ɹ��ʺʹ�ɹ���
//             float successRate = successCount / 36;
//             float bigSuccessRate = bigSuccessCount / 36;

//             // �����ۺϳɹ���
//             float compositeSuccessRate = 0.8f * successRate + 0.2f * bigSuccessRate;

//             return compositeSuccessRate;
//         }

//     }

//     private void AttackNeighboringCountry(Country country)
//     {
//         // �����ڽ��ĵжԹ��ҵ��߼�
//         // ������Ը�����Ϸ����͹����ɹ���������ս�����
//         // ����ֻ��һ���򵥵�ʾ�������蹥���ɹ��ʳ���50%ʱ�������ɹ�
//         foreach (Country neighbor in GetNeighbors(country))
//         {
//             if (neighbor.currentPlayer != country.currentPlayer && CalculateSuccessRate(country, neighbor) > 0.5f)
//             {
//                 // �����ɹ������¹��ҵĿ����ߺ;�����������Ϣ
//                 neighbor.currentPlayer = country.currentPlayer;
//                 neighbor.army = country.army - 1; // ���蹥����ʣ��һ������
//             }
//         }
//     }

//     private List<Country> GetNeighbors(Country selectedCountry)
//     {
//         List<Country> neighbors = new List<Country>();
//         if (Country.mapData.ContainsKey(selectedCountry.name))
//         {
//             List<string> neighborNames = Country.mapData[selectedCountry.name];
//             foreach (string neighborName in neighborNames)
//             {
//                 // �� countries �����в������ڹ��Ҳ����ӵ��б���
//                 Country neighbor = Array.Find(countries, c => c.name == neighborName);
//                 if (neighbor != null)
//                 {
//                     neighbors.Add(neighbor);
//                 }
//             }
//         }
//         return neighbors;
//     }
// }