using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface GGHECEJBHPI : global::FNLEEFFPAAJ<DHJLEHBOGBG>, CAMIJPMLKOA, global::DDLEHONFEBP<DHJLEHBOGBG>, AINHEFJAEPG, global::EOCHBHDFJOM<DHJLEHBOGBG>, global::CJOLMILKEEG<DHJLEHBOGBG>, global::AIGGMOPIIKJ<DHJLEHBOGBG>, global::GLEADKGGNKA<DHJLEHBOGBG>, MAGMDAGMOMO, global::JMLHLJFACAP<DHJLEHBOGBG>, GJPBOMNOBND, global::JNKPGKLPGFB<DHJLEHBOGBG>, global::BAIMOJOCJOK<DHJLEHBOGBG>, global::ANEBEINLICG<DHJLEHBOGBG>, global::ONMIGJKMOIP<DHJLEHBOGBG>, global::BHDCFHIHABO<DHJLEHBOGBG>, global::LIKLLLAINCP<DHJLEHBOGBG>, global::ENDMHNLLGFN<DHJLEHBOGBG>
{

 AHCBMDMIAAM ActiveGroup
{
get ;
}

 Behaviour AsBehaviour
{
get ;
}

 CancellationToken CancellationToken
{
get ;
}

 MMMPKIMPKKC ShapeCreationContext
{
get ;
}

 JDCIJIEOFOL owner
{
get ;
}

 global::HHOBPMOCKMJ<DHJLEHBOGBG> OnObjectTransformed
{
get ;
}

 global::HHOBPMOCKMJ<DHJLEHBOGBG> OnSelectionDeformed
{
get ;
}

	void SetSelectionBoundsDirty(bool OBBEGECCGCB = true, int MDJFLDPILCI = 0);

	void InvokeTranslationStartedEvent(Transform NIMCBGIBPPC, Vector3 HDCOHPOHJKD);

	void InvokeTranslationFinishedEvent();

	void InvokeRotationStartedEvent(Transform EHPMDEAEOGI, Vector3 HDCOHPOHJKD);

	void InvokeRotationFinishedEvent();

	void InvokeSelectionScalingStartedEvent(Transform AACLLIEFHDF, Vector3 HDCOHPOHJKD);

	void InvokeSelectionScalingFinishedEvent();

	void InvokeSelectionClonedEvent(Vector3 HDCOHPOHJKD);

	void InvokeSelectionDeletedEvent();

	IONEOHGOAML NotifyOfError(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, DHJLEHBOGBG GLHOACNHHMF, JDCIJIEOFOL FOILEMDKKCC);

	void QueueChangedColorEvent();

	void QueueChangedMaterialEvent(MJGMBIJIKFH LLMJGJOEMPP);

	void SetObjectTransformations(Guid[] CEAJEFGGINJ, Vector3[] ODFEKFPHMMP, Quaternion[] HBBDCGHEPNC, float[] DKJGMECNBHL, Dictionary<Guid, Vector3> KFDIOMHMMGE);

	global::NCOKFFGPIJM<bool> TryMergeShapeSelection(BJIJHMNPDCH NLINPCMLDBE, IReadOnlyList<BJIJHMNPDCH> GJODKIOFJLP);
}
