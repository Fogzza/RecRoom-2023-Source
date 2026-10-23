using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace RecRoom.Core
{
	public class ModifyTransformWithJobManager : SingletonMonoBehaviour<ModifyTransformWithJobManager>
	{
		private struct NFMPHPOHDDL
		{
			internal Quaternion HEGBBJCMANH;

			internal Vector3 INLGLHIPOMC;
		}

		private struct EHCJHMLPDHM
		{
			internal float DCKFIOFOJMD;

			internal Vector3 FHKGPLLJFNJ;

			public EHCJHMLPDHM(bool HAOPLALBIGI, bool DLEDANEAGDP)
			{
				DCKFIOFOJMD = 0f;
				FHKGPLLJFNJ = default;
			}
		}

		private struct MHKKLAPNEKN
		{
			internal float DMIPMFMPLAP;

			internal Vector3 OJBODCOIDJO;

			internal Quaternion GDHHCIKHKAJ;

			public MHKKLAPNEKN(float DMIPMFMPLAP, Vector3 OJBODCOIDJO, Quaternion GDHHCIKHKAJ)
			{
				this.DMIPMFMPLAP = 0f;
				this.OJBODCOIDJO = default;
				this.GDHHCIKHKAJ = default;
			}
		}

		private struct OJNLFLNDDGI
		{
			internal float LGECKEOAOAD;

			internal float FOCFODMODDH;

			internal float NLNNFJPDJIJ;

			internal float BGBBCPDLLNA;

			public OJNLFLNDDGI(Vector3 ACEPPAMDMBH, float NLNNFJPDJIJ, float BGBBCPDLLNA)
			{
				LGECKEOAOAD = 0f;
				FOCFODMODDH = 0f;
				this.NLNNFJPDJIJ = 0f;
				this.BGBBCPDLLNA = 0f;
			}
		}

		[BurstCompile]
		private struct GJMPPFILMOF : IJobParallelForTransform
		{
			public NativeArray<NFMPHPOHDDL> PCPEJHIMHJJ;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		[BurstCompile]
		private struct NLJJLMNHLIC : IJobParallelForTransform
		{
			[ReadOnly]
			public NativeArray<NFMPHPOHDDL> PCPEJHIMHJJ;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		[BurstCompile]
		private struct IGNPKCKEOHE : IJobParallelForTransform
		{
			[ReadOnly]
			public Vector3 LIHHPBGAKGN;

			[ReadOnly]
			public NativeArray<EHCJHMLPDHM> PCPEJHIMHJJ;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		[BurstCompile]
		private struct ALEEFKBLIHL : IJobParallelForTransform
		{
			[ReadOnly]
			public Quaternion HEGBBJCMANH;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		[BurstCompile]
		private struct BPOANLDAONC : IJobParallelForTransform
		{
			[ReadOnly]
			public float OKBAJEAPIHG;

			public NativeArray<MHKKLAPNEKN> PCPEJHIMHJJ;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		[BurstCompile]
		private struct IEBGEDIEKEC : IJobParallelForTransform
		{
			[ReadOnly]
			public float BBGNJMKOHPL;

			public NativeArray<OJNLFLNDDGI> PCPEJHIMHJJ;

			public void Execute(int GMEHLIHLGEH, TransformAccess FGNGGLFNLIP)
			{
			}
		}

		private global::HBLMKFEOLAA<MHKKLAPNEKN> IIGBPDCOMMM;

		private global::HBLMKFEOLAA<EHCJHMLPDHM> AIOJCHMEKMA;

		private global::HBLMKFEOLAA<OJNLFLNDDGI> MIAMFPOIPED;

		private EFKPBKNGBPH IFPMIBHNOIJ;

		private global::HBLMKFEOLAA<NFMPHPOHDDL> FKOOHAIKHHO;

		private EFKPBKNGBPH HNFPJDNGKMA;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void RegisterRotation(Transform DMLMGADKGFN, float BNJCOCNFFPM, Vector3 BHLNFEDMJDE)
		{
		}

		public void RegisterBillboard(Transform GIAGOGNPCPJ, bool HAOPLALBIGI, bool DLEDANEAGDP)
		{
		}

		public void RegisterPulsing(Transform LOLOBJALNIA, float NLNNFJPDJIJ, float BGBBCPDLLNA)
		{
		}

		public void UnregisterPulsing(Transform LOLOBJALNIA)
		{
		}

		public void RegisterGravityAligned(Transform FILGFFNMOBC)
		{
		}

		public void UnregisterGravityAligned(Transform FILGFFNMOBC)
		{
		}

		public void UnregisterRotation(Transform DMLMGADKGFN)
		{
		}

		public void UnregisterBillboard(Transform GIAGOGNPCPJ)
		{
		}

		public void RegisterSyncTransforms(Transform BFMOLHFDAJO, Transform GDPBOPKEFAN)
		{
		}

		public void UnregisterSyncTransforms(Transform BFMOLHFDAJO, Transform GDPBOPKEFAN)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
