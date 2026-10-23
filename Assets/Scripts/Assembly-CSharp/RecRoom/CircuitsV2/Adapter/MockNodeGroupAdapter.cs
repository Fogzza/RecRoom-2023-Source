using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.CircuitsV2.Adapter
{
	[Serializable]
	public sealed class MockNodeGroupAdapter : IAFGPKMBMBF
	{
		[EFEFIKFHIDK]
		[SerializeField]
		private SerializedGuid _graphId;

		[EFEFIKFHIDK]
		[SerializeField]
		private SerializedGuid _nodeId;

		[EFEFIKFHIDK]
		[SerializeField]
		private int _nodeDescIndex;

		[SerializeField]
		private string _name;

		[SerializeField]
		private bool _hasFunctionHeader;

		[SerializeField]
		private List<MockPortAdapter> _inputs;

		[SerializeField]
		private List<MockPortAdapter> _outputs;

		[CompilerGenerated]
		private Action<int> OnInputPortWillAdd;

		[CompilerGenerated]
		private Action<int, DGNNDGAENKL> OnInputPortDidAdd;

		[CompilerGenerated]
		private Action<int> OnOutputPortWillAdd;

		[CompilerGenerated]
		private Action<int, DGNNDGAENKL> OnOutputPortDidAdd;

		[CompilerGenerated]
		private Action<int, DGNNDGAENKL> OnInputPortWillRemove;

		[CompilerGenerated]
		private Action<int> OnInputPortDidRemove;

		[CompilerGenerated]
		private Action<int, DGNNDGAENKL> OnOutputPortWillRemove;

		[CompilerGenerated]
		private Action<int> OnOutputPortDidRemove;

		[CompilerGenerated]
		private Action OnDescWillRename;

		[CompilerGenerated]
		private Action OnDescDidRename;

		[CompilerGenerated]
		private ONMIMGFIEOA.LCEPBCKAING OnNodeDescIndexChanged;

		public object Object => null;

		public ref readonly Guid GraphId
		{
			get
			{
				throw null;
			}
		}

		public ref readonly Guid NodeId
		{
			get
			{
				throw null;
			}
		}

		public int NodeDescIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string Name => null;

		public bool HasFunctionHeader => false;

		public IReadOnlyList<DGNNDGAENKL> Inputs => null;

		public IReadOnlyList<DGNNDGAENKL> Outputs => null;

		public bool CanModifyInputs => false;

		public bool CanAddInputs => false;

		public bool CanRemoveInputs => false;

public event Action<int> CGMLHKOHDMB {
add {
		}
remove {
		}
}

public event Action<int, DGNNDGAENKL> KJDPCLBBHLF {
add {
		}
remove {
		}
}

public event Action<int> ELMJHBCIBLF {
add {
		}
remove {
		}
}

public event Action<int, DGNNDGAENKL> COHBDDGFAJF {
add {
		}
remove {
		}
}

public event Action<int, DGNNDGAENKL> HGLGFEBCJFP {
add {
		}
remove {
		}
}

public event Action<int> KDGADAAKGPF {
add {
		}
remove {
		}
}

public event Action<int, DGNNDGAENKL> GMBLGDFOCIM {
add {
		}
remove {
		}
}

public event Action<int> LAPJELHDOIE {
add {
		}
remove {
		}
}

public event Action ELCLLALHAMM {
add {
		}
remove {
		}
}

public event Action JKOLOIKLMPH {
add {
		}
remove {
		}
}

public event ONMIMGFIEOA.LCEPBCKAING ENJAKDCMLBF {
add {
		}
remove {
		}
}

		public void KEPKNHCKBNL()
		{
		}

		public void GCMMNEBCEKJ()
		{
		}

		public void JILOMOEEHMH(string INIOBIJJMJP)
		{
		}

		public void JDKGMMCLACB()
		{
		}

		public void MCIEBMALLBL()
		{
		}

		public void DKJKDNNODOM(string KNOPFGAGMCN, BHANLMJAEPJ NIFOGEBEDNG)
		{
		}

		public void AKGEBNLNFCF(int MHHENJGCFJF)
		{
		}

		public void BDAMDHEFDCG(string KNOPFGAGMCN, BHANLMJAEPJ NIFOGEBEDNG)
		{
		}

		public void HHPBMKKPEEF(int HPDCOAENBBE)
		{
		}

		public void NCDEMEJJJGK(in Guid GLLFFIFLOAG, in Guid KKBFAENPLID, int GHIHJACBECG)
		{
		}

		public void IMAGDCEAOJC(int MHHENJGCFJF, string KNOPFGAGMCN)
		{
		}

		public void OFBCHJBGALA(int HPDCOAENBBE, string KNOPFGAGMCN)
		{
		}

		public MockNodeGroupAdapter()
		{
		}

		public MockNodeGroupAdapter(in Guid GLLFFIFLOAG, in Guid KKBFAENPLID, int GHIHJACBECG, string KNOPFGAGMCN, List<MockPortAdapter> CIPFGHFHANF, List<MockPortAdapter> OOBDFIJCODF)
		{
		}
	}
}
