using AGUI.StackedUI;

public interface JCHEJJCHBKN
{
	T GetFlowByType<T>() where T : StackedUIFlowBase;

	TInterface GetFlowInterfaceByType<TInterface, TType>() where TInterface : class where TType : StackedUIFlowBase, TInterface;
}
