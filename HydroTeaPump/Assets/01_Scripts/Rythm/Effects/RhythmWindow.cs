using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WinTween.Position;

public class RhythmWindow : MonoBehaviour
{
    [SerializeField] private RhythmPlayerInput input = null;

    [SerializeField] private float bounceDuration;
    [SerializeField] private float bounceAmount;

    private void Start()
    {
        PositionEffects.Middle(0, true);
    }

    void Update()
    {
        bounceDuration = (float)NoteManager.GetBPM() / 1000.0f;

        if (input.up)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceUp(bounceDuration, bounceAmount);
        }
        if (input.down)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceDown(bounceDuration, bounceAmount);
        }
        if (input.left)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceLeft(bounceDuration, bounceAmount);
        }
        if (input.right)
        {
            PositionEffects.Middle(0, true);
            PositionEffects.BounceRight(bounceDuration, bounceAmount);
        }
    }



}