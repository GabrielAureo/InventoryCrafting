using UnityEngine;
using UnityEngine.Events;

public class MenuListItemEvents{
    public UnityAction<Item> onLeftClick;
    public UnityAction<Item> onRightClick;

    public UnityAction<Item> onHoverEnter;
   // public UnityAction<Item> onHoverExit;

    public MenuListItemEvents(UnityAction<Item> onLeftClick, UnityAction<Item> onRightClick, UnityAction<Item> onHoverEnter)
    {
        this.onHoverEnter = onHoverEnter;
        //this.onHoverExit = onHoverExit;
        this.onLeftClick = onLeftClick;
        this.onRightClick = onRightClick;
    }
}