﻿using TMPro;
using System.Collections;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private TextMeshPro scoreBoard;

    private Character character;

    public void OnEnable()
    {
        character = transform.GetComponentInChildren<Character>();
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        scoreBoard.text = character.GetCumulativeReward().ToString("f2");
    }
}
