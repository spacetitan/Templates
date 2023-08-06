using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private UIPanelName currentState = UIPanelName.NONE;

    public void SetState(UIPanelName state)
    {
        if(uIPanels.ContainsKey(state))
        {
            if(this.currentState != UIPanelName.NONE)
            {
                ClosePanel(currentState);
            }

            OpenPanel(state);
        }
    }
    private Dictionary<UIPanelName, UIPanel> uIPanels = new Dictionary<UIPanelName, UIPanel>();
    public void AddPanel(UIPanelName name, UIPanel panel) // add new panel names to Enum.cs
    {
        if(!uIPanels.ContainsKey(name))
        {
            uIPanels.Add(name, panel);
            panel.panelName = name;
        }
        else
        {
            Debug.LogError("Panel Already exists, please add new panel names to Enums.cs");
        }
    }

    public void RemovePanel(UIPanelName name)
    {
        if(uIPanels.ContainsKey(name))
        {
            uIPanels.Remove(name);
        }
    }
    private void OpenPanel(UIPanelName name)
    {
        if(uIPanels.ContainsKey(name))
        {
            uIPanels[name].OpenPanel();
            this.currentState = name;
        }
    }
    private void ClosePanel(UIPanelName name)
    {
        if(uIPanels.ContainsKey(name))
        {
            uIPanels[name].ClosePanel();
        }
    }

    public void Start()
    {
        this.SetState(UIPanelName.START);
    }
}
