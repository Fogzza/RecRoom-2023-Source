using System;
using System.Collections.Generic;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Shapes;
using UnityEngine;

public interface FNLEEFFPAAJ<T> : CAMIJPMLKOA, global::DDLEHONFEBP<T>, AINHEFJAEPG, global::EOCHBHDFJOM<T>, global::CJOLMILKEEG<T>, global::AIGGMOPIIKJ<T>, global::GLEADKGGNKA<T>, MAGMDAGMOMO, global::JMLHLJFACAP<T>, GJPBOMNOBND
{

 float SelectionScale
{
get ;
}

 float LocalSelectionScale
{
get ;
}

 EEANDDJEMJC SelectionChangedEvent
{
get ;
}

 bool CanScaleCurrentSelection
{
get ;
}

 bool CanDeformCurrentSelection
{
get ;
}

 bool CanCloneCurrentSelection
{
get ;
}

 bool CanMirrorCurrentSelection
{
get ;
}

	bool AddToSelection(T ICHBECDKHOJ);

	bool AddToSelection(int NIBKEGDHNIO, T[] OADJPPHPINN);

	void RemoveFromSelection(T ICHBECDKHOJ);

	void RemoveAllFromSelection();

	void StartScalingSelection();

	bool ScaleSelection(float LJCAHLAFIEP, Vector3? CDOJOBEAINO = null);

	bool DeformSelectionInDirection(Vector3 LKBBJDNDCBM, float LJCAHLAFIEP, Vector3 CDOJOBEAINO, bool DKOFNPIFHPG);

	void FinishScalingSelection();

	bool IsLoneShapeContainer(out Guid ELLOCGLOCEB, out ShapeContainer MOFGFAAHLIF);

	LAHBDKNMNHN CloneSelectionAndSelect(CreationContext.IMHJKLGAICO LBINIIAEHLF);

	void TrySetPreviousCloneMapping(Dictionary<Guid, Guid> COCAFFCAMKK);

	IReadOnlyCollection<Guid> CacheCurrentSelection();

	void SetSelectionFromCache(IReadOnlyCollection<Guid> MGGAFPGBPKK);

	void BufferCurrentSelection();

	bool SetSelectionFromBuffer(T ICHBECDKHOJ);

	ECMNCNMENKO CreateTransformationUndoEntry(string IEACNHGAIIE, IEnumerable<T> AAGLHJMICLO, bool LPEJLGKLDAG = false, bool NNAINJOHEAG = false, bool HNNFDAHEOHI = false);

	ECMNCNMENKO CreateCloneUndoEntry();
}
