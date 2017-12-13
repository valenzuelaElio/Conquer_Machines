using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    //Elio
    public GameObject DeckGameObject;
    public Deck Deck;

	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;

        //Elio
        Deck = DeckGameObject.GetComponent<Deck>();
	}
	
	public void OnDrop(PointerEventData data)
	{
		containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			receivingImage.overrideSprite = dropSprite;
        
    }

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
    }

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;

        //Elio
        Deck.DeckList.Add(Game.GameInstance.currentSelectedRobot.MyRobot);
        Deck.LastRobotAdded = Game.GameInstance.currentSelectedRobot.MyRobot;
        Debug.Log("Robot " + Game.GameInstance.currentSelectedRobot.MyRobot.robot_name + " agregado");
        //Elio
        Game.GameInstance.currentSelectedRobot = null;

        //Elio
        //Se vacia el robot seleccionado;
        //Game.GameInstance.currentSelectedRobot = null;

        Deck.UpdateLevelOfDeck(true);
        Deck.UpdateColors();
        Deck.UpdateDropSpot();
    }

    private Sprite GetDropSprite(PointerEventData data)
	{
        //Verifica si es el objeto que esta siendo arrastrado
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
        //VErifica si el objeto arrastrado tiene el componente "DragMe"
		var dragMe = originalObj.GetComponent<DragMe>();
		if (dragMe == null)
			return null;
		
        //Verifica si el objeto arrastrado tiene un sprite
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;

		return srcImage.sprite;
	}
}
