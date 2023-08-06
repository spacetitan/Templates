using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartMenu : UIPanel
{
    [Space(20)] 
    public Button startButton = null;

    private void Start()
    {
        UIManager.instance.AddPanel(UIPanelName.START, this);

        startButton.onClick.AddListener(()=>
        {
            UIManager.instance.SetState(UIPanelName.MAIN);
        });
    }

    public override void OnOpenPanel()
    {
        base.OnOpenPanel();
    }
}
