using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using NyaGames.Hero;

public class InitSo : MonoBehaviour
{
    [SerializeField] private SoHero hero;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        hero.Init();
        SceneManager.LoadScene("Game");
    }
}
