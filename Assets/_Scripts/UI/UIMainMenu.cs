using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIPanel
{
    [Space(20)] 
    public Button startButton = null;
    private void Start()
    {
        UIManager.instance.AddPanel(UIPanelName.MAIN, this);

        startButton.onClick.AddListener(()=>
        {
            UIManager.instance.SetState(UIPanelName.START);
        });
    }

    public override void OnOpenPanel()
    {
        base.OnOpenPanel();
    }
}
