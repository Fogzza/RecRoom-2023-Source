"""Read-only owner identities for narrowing the two-callback compiler fixture."""
import mmap
from collect_all_pinvoke_native import ExternMetadata
from inventory_recroom_game_root_native import ROOT

with (ROOT/'CodeSource/GameAssembly.dll').open('rb') as bf, (ROOT/'CodeSource/RecRoom_Data/il2cpp_data/Metadata/global-metadata.dat').open('rb') as mf, mmap.mmap(bf.fileno(),0,access=mmap.ACCESS_READ) as b, mmap.mmap(mf.fileno(),0,access=mmap.ACCESS_READ) as md:
    value = ExternMetadata(b, md)
    for index in range(value.count('typeDefinitions',88)):
        name = value.full_name(index)
        if name in ('MFENCGHNPBJ','GameRoot','BootSequence','SingletonMonoBehaviour`1'):
            print(value.type_info(index))
