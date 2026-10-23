"""Reuse pureCLI scoped owner reader for the explicitly requested COMLE/base owners."""
from pathlib import Path
import importlib.util
HERE=Path(__file__).resolve().parent
sp=importlib.util.spec_from_file_location('cli_owner_audit',HERE/'audit_hashable_scoped_vtable.py');h=importlib.util.module_from_spec(sp);sp.loader.exec_module(h)
if __name__=='__main__':
 h.NAMES={'COMLEJJIPLL','LMENEPLIBDK','LMENEPLIBDK`1'}
 h.main()
