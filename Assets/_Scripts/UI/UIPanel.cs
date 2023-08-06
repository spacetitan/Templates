using System.Collections;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public UIPanelName panelName = UIPanelName.NONE;
    public CanvasGroup canvasGroup = null;
    protected bool isOpen = false;
    protected bool fade = false;

    public void Awake()
    {
        this.isOpen = false;
        
        if(this.canvasGroup == null)
        {
            this.canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        }

        this.canvasGroup.alpha = 0;
        this.canvasGroup.interactable = false;
        this.canvasGroup.blocksRaycasts = false;
    }

    public virtual void OpenPanel()
    {
        if(this.fade)
        {
            SetCanvasGroupFade(true);
        }
        else
        {
            SetCanvasGroup(true);
            OnOpenPanel();
        }
        
    }

    public void ClosePanel()
    {
        if(this.fade)
        {
            SetCanvasGroupFade(false);
        }
        else
        {
            SetCanvasGroup(false);
            OnClosePanel();
        }
    }

    public void SetCanvasGroup(bool val)
    {
        if(val)
        {
            this.canvasGroup.alpha = 1;
        }
        else
        {
            this.canvasGroup.alpha = 0;
        }

        this.canvasGroup.interactable = val;
        this.canvasGroup.blocksRaycasts = val;
    }

    public void SetCanvasGroupFade(bool val)
    {
        StartCoroutine(FadeCG(val));
    }

    public virtual void OnOpenPanel()
    {
        this.isOpen = true;
    }
    public virtual void OnClosePanel()
    {
        this.isOpen = false;
    }

    public IEnumerator FadeCG(bool val)
    {
        if(val)
        {
            while(true)
            {
                float num = Mathf.Lerp(this.canvasGroup.alpha, 1, .25f);
                this.canvasGroup.alpha = num;
                yield return null;

                if(this.canvasGroup.alpha > .95f)
                {
                    this.canvasGroup.alpha = 1;
                    this.isOpen = true;
                    OnOpenPanel();
                    break;
                }
            }
        }
        else
        {
            while(true)
            {
                float num = Mathf.Lerp(this.canvasGroup.alpha, 0, .25f);
                this.canvasGroup.alpha = num;
                yield return null;

                if(this.canvasGroup.alpha < .05f)
                {
                    this.canvasGroup.alpha = 0;
                    this.isOpen = false;
                    OnClosePanel();
                    break;
                }
            }
        }

        this.canvasGroup.interactable = val;
        this.canvasGroup.blocksRaycasts = val;
    }
}
