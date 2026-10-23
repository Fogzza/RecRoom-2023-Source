using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Core.GameManagement;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestGearManager : MonoBehaviourPun
	{
		private sealed class KFKNINKLECI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestGearManager _003C_003E4__this;

			public EquipmentSpawnerChest chest;

			private float _003CdeltaArcAngle_003E5__2;

			private int _003CnumSpawns_003E5__3;

			private int _003Ci_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public KFKNINKLECI(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const float DDLIIAGKEKD = 0.05f;

		[SerializeField]
		private JMGADHIDPHD campaign;

		private static QuestGearManager EGAIHCNFOEN;

		private global::OFIKOABIHEL<GameObject> KODCMOABHDC;

		private JFANOOIELPK HDCLOEKCDKN;

		private JFANOOIELPK BPLAODJBOCM;

		private JBGFOIKBKED[] HAHNCCDGMMN;

		private JBGFOIKBKED[] HCGIKJMEBBC;

		private QuestGear FLCKPKEKMEG;

public static QuestGearManager Instance
{
get 		{
			return null;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		private void DNNOOOGOPID()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void IEEHHONMJGK(EquipmentSpawnerChest IEODCBDCDFF)
		{
		}

		private IEnumerator HHGANCPILDB(EquipmentSpawnerChest IEODCBDCDFF)
		{
			return null;
		}

		private bool FFPJKGINBCC(Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
			return false;
		}

		private bool CCKAGNDOMLJ(GameObject IPLDMJIIGGD, Vector3 ELGLOEDDKAJ, Quaternion FJKPMOAGDOI, float LGPIDIPODLD, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
			return false;
		}

		private void FEJEKDDPHPD(SpawnableTool LAKEAGALHHL)
		{
		}

		private void BEGGJOINPOI(QuestGameplayRoom ELFFAOHGEGD)
		{
		}

		private void HANGBFBOJNE(Tool IEGMBEPJMGC)
		{
		}
	}
}
