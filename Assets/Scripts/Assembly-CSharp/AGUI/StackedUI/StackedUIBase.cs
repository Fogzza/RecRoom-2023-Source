using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.DataStructures;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public abstract class StackedUIBase : MonoBehaviourPun, DIJCJNKIIPE, JCHEJJCHBKN, MAECJBCMGMK
	{
		[Serializable]
		protected class FlowPrefabResourceReference : ResourcePrefabReference<StackedUIFlowBase>
		{
			private static readonly PMDPPPJKLAO prefabCache;

			[SerializeField]
			public bool FirstFlow;

			[SerializeField]
			public string TypeName;

			public override StackedUIFlowBase EEOHKMPFBKB()
			{
				return null;
			}
		}

		private Action<OMNLIPPAPDI> JCAGAIGLJGC__BackingField;

		private Action<bool> DCEJIBEJKJK__BackingField;

		private Action<StackedUIFlowBase> JHPLIEAMDPA__BackingField;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private RectTransform screenBase;

		[SerializeField]
		private FlowPrefabResourceReference[] flowResources;

		private Stack<StackedUIFlowBase> CALBGMMAMPM;

		private Dictionary<Type, StackedUIFlowBase> KHAPPIEBKEK;

		private StackedUIFlowBase ABPJPJBJGBC;

		public global::HHOBPMOCKMJ<StackedUIFlowBase> CurrentFlowChanged;

		private StackedUIFlowBase LOIMBCGKJOJ;

		private UIInteractionRestriction[] KMHJOAKFLAD;

		private RectTransform PBLNGAJGCMP;

		private FIHGBEHGLGB MKJNFIJEHDD;

		private PDPHLPEHFOO PCEOANEBLFE;

		private OMNLIPPAPDI AEDCDCNEBKD;

		protected bool CFIFOKNGKBB;

		private float DIBEJEFGOPF;

		private readonly Stack<StackedUIFlowBase> CDDMGNBOKLB;

public Canvas Canvas
{
get 		{
			return null;
		}

}

public RectTransform CanvasRectTransform
{
get 		{
			return null;
		}

}

protected IReadOnlyList<FlowPrefabResourceReference> FOPJLMODOOE
{
get 		{
			return null;
		}

}

public IReadOnlyList<StackedUIFlowBase> FlowStackToList
{
get 		{
			return null;
		}

}

public StackedUIFlowBase CurrentFlow
{
get 		{
			return null;
		}

private set {
		}
}

public StackedUIFlowBase PreviousFlow
{
get 		{
			return null;
		}

private set {
		}
}

protected virtual string NPNGNBNICFF
{
get 		{
			return null;
		}

}

public OMNLIPPAPDI Size
{
get 		{
			return OMNLIPPAPDI.NORMAL;
		}

set {
		}
}

public int FlowStackCount
{
get 		{
			return 0;
		}

}

public bool FullyVisible
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool SupportsResizing
{
get 		{
			return false;
		}

}

public float CanvasZScale
{
get 		{
			return 0f;
		}

set {
		}
}

public event Action<OMNLIPPAPDI> ResizeCompleteEvent {
add {
		}
remove {
		}
}

public event Action<bool> FullyVisibleChanged {
add {
		}
remove {
		}
}

public event Action<StackedUIFlowBase> FlowPushed {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected void DNLGGKJCDCK()
		{
		}

		protected virtual FlowPrefabResourceReference GCNODPLEIKH()
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected virtual void GGAKOMGHAGK(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		private void CDDFPJENEKM()
		{
		}

		protected virtual void DNPOGCFJOAC()
		{
		}

		private void LJEDELMKMJL()
		{
		}

		protected virtual void KHOACLMDKOG()
		{
		}

		protected virtual void JFAFAIMKJKL()
		{
		}

		protected void MAODJCAELAP()
		{
		}

		public void Button_PushFlow(StackedUIFlowBase flow)
		{
		}

		public void PushFlow(StackedUIFlowBase ELNPJBMKDAE, string LDPCFDMCJLH = null)
		{
		}

		public T PushFlow<T>(string LDPCFDMCJLH = null) where T : StackedUIFlowBase
		{
			return null;
		}

		protected virtual void DGPFMFMJNEL(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		public void Button_PopFlow()
		{
		}

		public bool PopFlow()
		{
			return false;
		}

		public void PopAllFlows()
		{
		}

		public bool IsFlowOnStack(StackedUIFlowBase ELNPJBMKDAE)
		{
			return false;
		}

		public StackedUIFlowBase PeekFlow()
		{
			return null;
		}

		public bool RefreshTopFlow()
		{
			return false;
		}

		protected virtual bool GKFDOKDBIBF()
		{
			return false;
		}

		protected virtual bool NNJNFCGMJKG()
		{
			return false;
		}

		private void LNOMPBNPDIM(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool FHAGPHDEEGA)
		{
		}

		protected virtual void HCMBCGIBFGA(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool FHAGPHDEEGA)
		{
		}

		protected void BPMFNJOAMOO(bool BMGEHFPFCBJ, object IALNODEHBNN)
		{
		}

		private void GCNGNOMGILI()
		{
		}

		private void JKCGPPPGPOD(StackedUIFlowBase ELNPJBMKDAE, bool BMGEHFPFCBJ, bool KBEDPGHKMMK = false)
		{
		}

		private void CJCEGJKMKOJ(StackedUIFlowBase ELNPJBMKDAE)
		{
		}

		private OMNLIPPAPDI ILMLBBMIMNJ()
		{
			return OMNLIPPAPDI.NORMAL;
		}

		private void PBPPIFMAGGP(OMNLIPPAPDI NOCCMAIOCDF, bool JJBALMEAJGH)
		{
		}

		public bool CanInteract(Selectable DNPIJEOOLKB)
		{
			return false;
		}

		public bool TryGetFlowByType<T>(out T ELNPJBMKDAE) where T : StackedUIFlowBase
		{
			ELNPJBMKDAE = null;
			return false;
		}

		public T GetFlowByType<T>() where T : StackedUIFlowBase
		{
			return null;
		}

		public TInterface GetFlowInterfaceByType<TInterface, TType>() where TInterface : class where TType : StackedUIFlowBase, TInterface
		{
			return null;
		}

		private StackedUIFlowBase KCIAGMMGJON(FlowPrefabResourceReference JDAONJEJBKA)
		{
			return null;
		}
	}
}
