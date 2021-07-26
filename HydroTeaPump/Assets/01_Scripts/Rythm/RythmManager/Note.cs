﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    void OnEnable()
    {
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();
        noteImage.enabled = true;
    }

    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
}