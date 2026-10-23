using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public abstract class ConfigurableSelector<T> : MonoBehaviourPun, DJLCHGFCFAD
	{
		[SerializeField]
		private SerializedGuid serializedGuid;

		protected T KCAPLJEHMMI;

		private global::MOBDJNEDDKC<int> EPFPJOGEEEB;

public int SelectedId
{
get 		{
			return 0;
		}

set {
		}
}

protected abstract T KBADFJGFOBL
{
get ;
}

protected abstract IEnumerable<T> DLKNNONDAHP
{
get ;
}

protected abstract string IEABLNBBGBM
{
get ;
}

public virtual bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		public abstract int GetOptionId(T GJEGFNAKHOK);

		protected abstract void MCBJJEMDNAL(T GJEGFNAKHOK);

		protected virtual void HEGENLMAODF()
		{
		}

		protected void KPFLPBAAJNC()
		{
		}

		protected abstract void DMDKANABANN(T GJEGFNAKHOK);

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void AddSelectedIdConfigurableEnum<TEnum>(CreationObject BPEGJLIMPPJ, string KNOPFGAGMCN, int LAGADKBKLAD) where TEnum : Enum
		{
		}

		[CompilerGenerated]
		private bool LABGCPFKEJN(T IBALDFBGBGL)
		{
			return false;
		}

		[CompilerGenerated]
		private bool CELEILIALAO(ODLAEGABHCA IBALDFBGBGL)
		{
			return false;
		}

		[CompilerGenerated]
		private int GBPKLIHJBHN<TEnum>() where TEnum : Enum
		{
			return 0;
		}

		[CompilerGenerated]
		private void MELDCFDFKKI<TEnum>(int IPMIIEAGJKC) where TEnum : Enum
		{
		}
	}
}
