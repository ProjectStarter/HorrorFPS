using UnityEngine;
using System.Collections;

public class UIScaling : MonoBehaviour {

	private static UIScaling _instance = null;
	public static UIScaling Instance
	{
		get
		{
			return _instance;
		}
	}

	[SerializeField] private bool manualSetup;

	private const string GAME_ROOT_NAME = "GameRoot";
	private const string BASE_OBJECT_NAME = "Base";

	private const int MAX_WIDTH = 1920;
	private const int MAX_HEIGHT = 1080;

	private static Vector3 computedScale = Vector3.one;

	private UIWidget baseUIWidget;
	private int baseUIWidgetWidth = 0;
	private int baseUIWidgetHeight = 0;

	void Awake()
	{
		_instance = this;
		this.baseUIWidget = this.GetComponent<UIWidget> ();
	}
	// Use this for initialization
	void Start () {
		if(!manualSetup)
		{
			ForceSetup();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void UpdateAllAnchors()
	{
		this.baseUIWidget.UpdateAnchors ();

		UIPanel[] panelChildren = this.baseUIWidget.GetComponentsInChildren<UIPanel> ();

		foreach(UIPanel childPanel in panelChildren)
		{
			childPanel.UpdateAnchors();
		}

		UIWidget[] widgetChildren = this.baseUIWidget.GetComponentsInChildren<UIWidget> ();

		foreach(UIPanel childWidget in widgetChildren)
		{
			childWidget.UpdateAnchors();
		}
	}

	public void ForceSetup()
	{
		this.baseUIWidgetWidth = this.baseUIWidget.width;
		this.baseUIWidgetHeight = this.baseUIWidget.height;

		computedScale.x = this.baseUIWidgetWidth * 1.0f / MAX_WIDTH;
		computedScale.y = this.baseUIWidgetHeight * 1.0f / MAX_HEIGHT;
		computedScale.z = computedScale.x;
		this.transform.localScale = computedScale;

		this.UpdateAllAnchors ();
	}

	public static Vector3 GetComputedScale()
	{
		return computedScale;
	}


}
