using System;
using System.Collections.Generic;

public interface IAFGPKMBMBF
{

 object Object
{
get ;
}

 ref readonly Guid GraphId
{
get ;
}

 ref readonly Guid NodeId
{
get ;
}

 int NodeDescIndex
{
get ;
}

 string Name
{
get ;
}

 bool HasFunctionHeader
{
get ;
}

 IReadOnlyList<DGNNDGAENKL> Inputs
{
get ;
}

 IReadOnlyList<DGNNDGAENKL> Outputs
{
get ;
}

 bool CanModifyInputs
{
get ;
}

 bool CanAddInputs
{
get ;
}

 bool CanRemoveInputs
{
get ;
}

 event Action<int> CGMLHKOHDMB;

 event Action<int, DGNNDGAENKL> KJDPCLBBHLF;

 event Action<int> ELMJHBCIBLF;

 event Action<int, DGNNDGAENKL> COHBDDGFAJF;

 event Action<int, DGNNDGAENKL> HGLGFEBCJFP;

 event Action<int> KDGADAAKGPF;

 event Action<int, DGNNDGAENKL> GMBLGDFOCIM;

 event Action<int> LAPJELHDOIE;

 event Action ELCLLALHAMM;

 event Action JKOLOIKLMPH;

 event ONMIMGFIEOA.LCEPBCKAING ENJAKDCMLBF;

	void GCMMNEBCEKJ();

	void JILOMOEEHMH(string INIOBIJJMJP);

	void JDKGMMCLACB();

	void MCIEBMALLBL();

	void DKJKDNNODOM(string KNOPFGAGMCN, BHANLMJAEPJ NIFOGEBEDNG);

	void AKGEBNLNFCF(int MHHENJGCFJF);

	void BDAMDHEFDCG(string KNOPFGAGMCN, BHANLMJAEPJ NIFOGEBEDNG);

	void HHPBMKKPEEF(int HPDCOAENBBE);

	void IMAGDCEAOJC(int MHHENJGCFJF, string KNOPFGAGMCN);

	void OFBCHJBGALA(int HPDCOAENBBE, string KNOPFGAGMCN);
}
