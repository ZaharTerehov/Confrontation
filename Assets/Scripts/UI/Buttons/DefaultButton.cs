
using UI.Controllers;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class DefaultButton : Button
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            AudioController.PlaySound("Click");
            base.OnPointerClick(eventData);
        }
    }
}