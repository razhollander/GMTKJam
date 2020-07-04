using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Linq;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    const float TIMESCALE_CHNGE_DAURATION = 0.4f;
    [SerializeField] PrefabsCollectionObject _prefabsCollectionObject;

    public static GameManager Instance;

    public AssetLoadHandler AssetLoadHandler;
    public GamePrefHandler GamePrefHandler;
    public GameStateManager GameStateManager;

    public event Action OnGamePaused;
    public event Action OnGameResumed;



    void Awake()
    {
        Instance = this;
        GamePrefHandler = new GamePrefHandler();
        AssetLoadHandler = new AssetLoadHandler(_prefabsCollectionObject);
        GameStateManager = new GameStateManager();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        OnGamePaused?.Invoke();
    }
    public void ResumeGame()
    {
        Time.timeScale = 0.3f;
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, TIMESCALE_CHNGE_DAURATION);
        OnGameResumed?.Invoke();
    }
    public void EndGame()
    {
        GameStateManager.SwitchGameState<MainMenuState>();
    }
    public void PlayGame()
    {
        GameStateManager.SwitchGameState<NormalPlayState>();
    }   
}
