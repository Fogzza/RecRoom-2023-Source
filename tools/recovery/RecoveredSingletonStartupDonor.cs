// Exact original owner, field, base and generic constraint; only two selected bodies.
public class SingletonMonoBehaviour<T> : UnityEngine.MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    private static T CMDPMJBEBAB;
// Replacement members inside the original SingletonMonoBehaviour<T> only.
// Keep original private static CMDPMJBEBAB and constraint T : SingletonMonoBehaviour<T>.
protected virtual void Awake()
{
    if (CMDPMJBEBAB != null)
    {
        UnityEngine.Debug.LogWarning(string.Concat("Created more than one singleton of ", typeof(T).ToString(), "! Destroying the old one."));
        UnityEngine.Object.Destroy(CMDPMJBEBAB.gameObject);
    }
    CMDPMJBEBAB = (T)this;
}

protected virtual void OnDestroy()
{
    if (CMDPMJBEBAB == this)
        CMDPMJBEBAB = null;
}

}
