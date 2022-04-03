using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameState : MonoBehaviour
{
    [SerializeField]private GameObject game;

    private void OnEnable()
    {
        game.SetActive(true);
    }

    private void OnDisable()
    {
        game.SetActive(false);
    }

    private void OnDestroy()
    {
        game.SetActive(false);
    }
}
