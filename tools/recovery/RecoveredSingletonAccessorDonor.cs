// Original owner, self constraint and private field. Import only the two getters.
public class SingletonMonoBehaviour<T>:UnityEngine.MonoBehaviour where T:SingletonMonoBehaviour<T>
{
    private static T CMDPMJBEBAB;
// Replacement properties inside the original SingletonMonoBehaviour<T> only.
// Preserve its original private static T CMDPMJBEBAB, self constraint and metadata.
public static T Instance
{
    get { return CMDPMJBEBAB; }
}
public static bool IsInitialized
{
    get { return Instance != null; }
}

}
