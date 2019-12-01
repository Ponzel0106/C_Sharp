import winreg
import binascii
key = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, r"SOFTWARE\\", 0, winreg.KEY_READ  | winreg.KEY_WOW64_64KEY)
subKey = winreg.CreateKey(key, r'Ponzel\\')
winreg.SetValueEx(subKey,'P1', 0 , winreg.REG_SZ, 'Студент кафедри')
winreg.SetValueEx(subKey,'P2', 0 , winreg.REG_BINARY,  binascii.unhexlify("2A4BCEDF"))
winreg.SetValueEx(subKey,'P3', 0 , winreg.REG_DWORD, 0x2A4BCEDF)

