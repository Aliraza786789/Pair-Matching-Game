using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FruitsType
{
    Apple,
    Banana,
    Peach,
    MixFruits,
    YellowApple,
    AppleAndBanana,
    Lemon,
    Coconut,
    Mango,
    BlueMango,
    Pear,
    PineApple,
    PearCut,
    Strawberry,
    Orange,
    Almond,
    OrangeWatermelon,
    Muskmelon,
    Artery,
    Stars
}

public class CardSpawner : MonoBehaviour
{
    public CardScript cardPrefab;
    public GameObject cardSpawnPosition;
    public List<CardScript> allCards;
    public Vector2 startPos = new Vector2(-2.15f, 3.62f);
    public Vector2 offSet = new Vector2(1.5f, 1.52f);
    public Vector2 rowsAndColumns;
    public Material[] materialArray;


    public void Initialize()
    {
        Init();
    }

    private void Init()
    {
        CardSpawnerTech((int)rowsAndColumns.x, (int)rowsAndColumns.y);
        MovePicture((int)rowsAndColumns.x, (int)rowsAndColumns.y, startPos, offSet);
    }

    public void CardSpawnerTech(int rows, int columns)
    {
        List<FruitsType> identifiers = GenerateShuffledIdentifiers(rows * columns / 2);
        int index = 0;

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var tempCard = (CardScript)Instantiate(cardPrefab, cardSpawnPosition.transform.position,
                    Quaternion.identity);

                tempCard.name = "Card_" + col + "_" + row;
                tempCard.transform.localScale = ReferenceManager.LevelScript.pictureScale;
                tempCard.SetIdentifier(tempCard, identifiers[index], materialArray);
                allCards.Add(tempCard);
                index++;
            }
        }

        ReferenceManager.Instance.gameManager.totalPair
            = ReferenceManager.Instance.cardSpawner.allCards.Count / 2;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    List<FruitsType> GenerateShuffledIdentifiers(int pairsCount)
    {
        List<FruitsType> identifiers = new List<FruitsType>();

        // Add each fruit type twice to create pairs
        for (int i = 0; i < pairsCount; i++)
        {
            identifiers.Add((FruitsType)i);
            identifiers.Add((FruitsType)i);
        }

        // Shuffle the identifiers
        Shuffle(identifiers);
        return identifiers;
    }

    public void MovePicture(int rows, int columns, Vector2 pos, Vector2 offSets)
    {
        var index = 0;
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var tempPosition = new Vector3((pos.x + (offSets.x * row)), (pos.y - (offSets.y * col)), 86f);
                StartCoroutine(MoveToPosition(tempPosition, allCards[index]));
                index++;
            }
        }
    }

    public int distanceBetweenCards = 10;

    private IEnumerator MoveToPosition(Vector3 target, CardScript card)
    {
        while (card.transform.position != target)
        {
            card.transform.position =
                Vector3.MoveTowards(card.transform.position, target, distanceBetweenCards * Time.deltaTime);
            print("I AM WORKING");
            yield return null;
        }
    }
}