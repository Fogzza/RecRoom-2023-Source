using System.Collections.Generic;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.AGUI.Expresso
{
	public class ExpressoUI : MonoBehaviour
	{
		public enum CNHHDFEJPAJ
		{
			Translate = 0,
			Twist = 1
		}

		[SerializeField]
		private ExpressoUIFlow rootFlowPrefab;

		[SerializeField]
		private RecRoomAudioClip showUIAudio;

		[SerializeField]
		public bool AlignToHandRotation;

		[SerializeField]
		private float handFollowDuration;

		[SerializeField]
		private float initialVelocityMultiplier;

		public Collider selectionCollider;

		private bool PPKENGMKFJB;

		private bool CKMPNLHFJGC;

		private float ABOPJHJOCBH;

		private List<ExpressoUIFlow> GLLPIAIHNCM;

		private Stack<ExpressoUIFlow> CALBGMMAMPM;

		private PlayerHand LFABMBGNFFI;

		private ALFNPNHKGCE MNCHCMPPLKO;

public PlayerHand OperatingHand
{
get 		{
			return null;
		}

}

public ALFNPNHKGCE stateMachine
{
get 		{
			return null;
		}

set {
		}
}

public bool Showing
{
get 		{
			return false;
		}

}

private ExpressoUIFlow FGJBDDFGICA
{
get 		{
			return null;
		}

}

		private void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		public void ShowUI(bool KBHLDNPHEKG, PlayerHand PMNLJGLDMJN = null)
		{
		}

		public void PushFlow(ExpressoUIFlow DGLENJPGIKH, bool KDCHFDKGMAK = true, bool MCDNCKJMHNG = false)
		{
		}

		public bool PopFlow(bool FFMHALMFGFG = true)
		{
			return false;
		}

		private ExpressoUIFlow AMJKAMFHNJH(ExpressoUIFlow DGLENJPGIKH)
		{
			return null;
		}

		private void AFKCOHDNIML()
		{
		}

		private Quaternion KNJGKEBKKOM()
		{
			return default;
		}

		public void CancelExpresso()
		{
		}
	}
}
