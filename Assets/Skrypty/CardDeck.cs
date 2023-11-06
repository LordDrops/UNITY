using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public static List<Card> CardList = new List<Card>();



     void Awake()
    {
        //back cards
        CardList.Add(new Card(0,ENUM_Tiers.I, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(1,ENUM_Tiers.I, 0, 0, 0, 1, 0, 2, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(2,ENUM_Tiers.I, 0, 0, 2, 0, 0, 2, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(3,ENUM_Tiers.I, 0, 1, 0, 3, 0, 1, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(4,ENUM_Tiers.I, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(5,ENUM_Tiers.I, 0, 0, 1, 1, 2, 1, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(6,ENUM_Tiers.I, 0, 0, 2, 1, 2, 0, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(7,ENUM_Tiers.I, 1, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(8,ENUM_Tiers.II, 1, 0, 3, 0, 2, 2, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(9,ENUM_Tiers.II, 1, 2, 3, 0, 0, 3, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(10,ENUM_Tiers.II, 2, 0, 0, 2, 1, 4, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(11,ENUM_Tiers.II, 2, 0, 5, 0, 0, 0, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(12,ENUM_Tiers.II, 2, 0, 0, 3, 0, 5, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(13,ENUM_Tiers.II, 3, 6, 0, 0, 0, 0, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(14,ENUM_Tiers.III, 3, 0, 3, 3, 3, 5, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(15,ENUM_Tiers.III, 4, 0, 0, 7, 0, 0, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(16,ENUM_Tiers.III, 4, 3, 0, 6, 0, 3, 1, 0, 0, 0, 0, null));
        CardList.Add(new Card(17,ENUM_Tiers.III, 5, 3, 0, 7, 0, 0, 1, 0, 0, 0, 0, null));

        //Blue cards
        CardList.Add(new Card(18,ENUM_Tiers.I, 0, 2, 1, 0, 0, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(19, ENUM_Tiers.I, 0, 1, 1, 2, 0, 1, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(20, ENUM_Tiers.I, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(21, ENUM_Tiers.I, 0, 0, 0, 1, 1, 3, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(22, ENUM_Tiers.I, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(23, ENUM_Tiers.I, 0, 0, 1, 2, 0, 2, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(24, ENUM_Tiers.I, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(25, ENUM_Tiers.I, 1, 0, 0, 4, 0, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(26, ENUM_Tiers.II, 1, 0, 0, 3, 2, 2, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(27, ENUM_Tiers.II, 1, 3, 0, 0, 2, 3, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(28, ENUM_Tiers.II, 2, 0, 5, 0, 3, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(29, ENUM_Tiers.II, 2, 0, 0, 0, 5, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(30, ENUM_Tiers.II, 2, 4, 2, 1, 0, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(31, ENUM_Tiers.II, 3, 0, 0, 0, 6, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(32, ENUM_Tiers.III, 3, 5, 3, 3, 0, 3, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(33, ENUM_Tiers.III, 4, 0, 7, 0, 0, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(34, ENUM_Tiers.III, 4, 3, 6, 0, 3, 0, 0, 0, 0, 1, 0, null));
        CardList.Add(new Card(35, ENUM_Tiers.III, 5, 0, 7, 0, 3, 0, 0, 0, 0, 1, 0, null));

        //GREEN CARDS

        CardList.Add(new Card(36, ENUM_Tiers.I, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(37, ENUM_Tiers.I, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(38, ENUM_Tiers.I, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(39, ENUM_Tiers.I, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(40, ENUM_Tiers.I, 0, 2, 1, 1, 1, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(41, ENUM_Tiers.I, 0, 2, 0, 2, 1, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(42, ENUM_Tiers.I, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(43, ENUM_Tiers.I, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(44, ENUM_Tiers.II, 1, 0, 3, 3, 0, 2, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(45, ENUM_Tiers.II, 1, 2, 2, 0, 3, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(46, ENUM_Tiers.II, 2, 1, 4, 0, 2, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(47, ENUM_Tiers.II, 2, 0, 0, 0, 0, 5, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(48, ENUM_Tiers.II, 2, 0, 0, 0, 5, 3, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(49, ENUM_Tiers.II, 3, 0, 0, 0, 0, 6, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(50, ENUM_Tiers.III, 3, 3, 5, 3, 3, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(51, ENUM_Tiers.III, 4, 0, 3, 0, 6, 3, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(52, ENUM_Tiers.III, 4, 0, 0, 0, 7, 0, 0, 0, 0, 0, 1, null));
        CardList.Add(new Card(53, ENUM_Tiers.III, 5, 0, 0, 0, 7, 3, 0, 0, 0, 0, 1, null));

        //RED CARDS
        CardList.Add(new Card(54, ENUM_Tiers.I, 0, 0, 3, 0, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(55, ENUM_Tiers.I, 0, 3, 1, 1, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(55, ENUM_Tiers.I, 0, 0, 0, 0, 2, 1, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(56, ENUM_Tiers.I, 0, 2, 2, 0, 0, 1, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(57, ENUM_Tiers.I, 0, 1, 2, 0, 1, 1, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(58, ENUM_Tiers.I, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(59, ENUM_Tiers.I, 0, 0, 2, 2, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(60, ENUM_Tiers.I, 1, 0, 4, 0, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(61, ENUM_Tiers.II, 1, 3, 0, 2, 3, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(62, ENUM_Tiers.II, 1, 3, 2, 2, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(63, ENUM_Tiers.II, 2, 0, 1, 0, 4, 2, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(64, ENUM_Tiers.II, 2, 5, 3, 0, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(65, ENUM_Tiers.II, 2, 5, 0, 0, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(66, ENUM_Tiers.II, 3, 0, 0, 6, 0, 0, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(67, ENUM_Tiers.III, 3, 3, 3, 0, 5, 3, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(68, ENUM_Tiers.III, 4, 0, 0, 0, 0, 7, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(69, ENUM_Tiers.III, 4, 0, 0, 3, 3, 6, 0, 0, 1, 0, 0, null));
        CardList.Add(new Card(70, ENUM_Tiers.III, 5, 0, 0, 3, 0, 7, 0, 0, 1, 0, 0, null));

        //WHITE CARDS

        CardList.Add(new Card(71, ENUM_Tiers.I, 0, 1, 0, 0, 2, 2, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(72, ENUM_Tiers.I, 0, 1, 0, 2, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(73, ENUM_Tiers.I, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(74, ENUM_Tiers.I, 0, 0, 0, 0, 3, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(75, ENUM_Tiers.I, 0, 0, 0, 0, 2, 2, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(76, ENUM_Tiers.I, 0, 1, 0, 1, 1, 2, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(77, ENUM_Tiers.I, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(78, ENUM_Tiers.I, 1, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(79, ENUM_Tiers.II, 1, 2, 0, 2, 0, 3, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(80, ENUM_Tiers.II, 1, 0, 2, 3, 3, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(81, ENUM_Tiers.II, 2, 2, 0, 4, 0, 1, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(82, ENUM_Tiers.II, 2, 0, 0, 5, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(83, ENUM_Tiers.II, 2, 3, 0, 5, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(84, ENUM_Tiers.II, 3, 0, 6, 0, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(85, ENUM_Tiers.III, 3, 3, 0, 5, 3, 3, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(86, ENUM_Tiers.III, 4, 7, 0, 0, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(87, ENUM_Tiers.III, 4, 6, 3, 3, 0, 0, 0, 1, 0, 0, 0, null));
        CardList.Add(new Card(88, ENUM_Tiers.III, 5, 7, 3, 0, 0, 0, 0, 1, 0, 0, 0, null));



    }





}
