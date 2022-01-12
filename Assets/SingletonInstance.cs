using UnityEngine;
public class SingletonInstance<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance = null;

	protected static event System.Action OnInitializeEvent;

	protected virtual bool AutoNotifyInitialized { get => true; }

	public static void WhenInitialized(System.Action action)
	{
		if (instance)
		{
			action.Invoke();
		}
		else
		{
			OnInitializeEvent += action;
		}
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = (T)FindObjectOfType(typeof(T));

			gameObject.name = gameObject.name;
			OnInitialize();

			if (AutoNotifyInitialized)
			{
				NotifyInitialized();
			}
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	protected static void NotifyInitialized()
	{
		OnInitializeEvent?.Invoke();
		OnInitializeEvent = null;
	}

	public static T GetInstance()
	{
		return instance;
	}

	protected virtual void OnInitialize() { }

	protected virtual void OnDestroy() { }
}
