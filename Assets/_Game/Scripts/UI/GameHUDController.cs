using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameHUDController : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    
    private List<Button> _menuButtons = new List<Button>();
    private AudioSource _audioSource;
    private GameFSM _stateMachine;
    public void Initialize(GameFSM stateMachine)
    {
        _stateMachine = stateMachine;
    }


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _stateMachine = GetComponent<GameFSM>();

        _button = _document.rootVisualElement.Q("PauseButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnPauseClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }
    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPauseClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }
    private void OnPauseClick(ClickEvent evt)
    {
        Debug.Log("Pause button clicked.");
        if (_stateMachine.PauseState != null)
        {
            _stateMachine.ChangeState(_stateMachine.PauseState);
        }
        else
        {
            Debug.LogError("PauseState is not initialized!");
        }
    }



    private void OnAllButtonsClick(ClickEvent evt)
    {
        _audioSource.Play();
    }
}
