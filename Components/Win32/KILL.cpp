#pragma warning(suppress : 4996)
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <windows.h>
#include <winbase.h>
#include <tlhelp32.h>
#pragma comment(lib,"kernel32.lib")
#pragma comment(lib,"advapi32.lib")
/* AdminCon 7.0 Command Line Interface Edition - Source Code - KILL.CPP
 * Intro: Kill the specified process
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition_Classes_Win32{
	void EnableDebugPriv() {
	HANDLE hToken;
	TOKEN_PRIVILEGES tkp;
	OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken);
	LookupPrivilegeValue(NULL, SE_SHUTDOWN_NAME, &tkp.Privileges[0].Luid);
	tkp.PrivilegeCount = 1;
	tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
	AdjustTokenPrivileges(hToken, FALSE, &tkp, 0, NULL, NULL);
	CloseHandle(hToken);
}
int pskill(int id)   //kill process by pid
{
	HANDLE hProcess = NULL;
	//Open the target process
	hProcess = OpenProcess(PROCESS_TERMINATE, FALSE, id);
	if (hProcess == NULL) {
		wprintf(L"\nOpen Process failed:%d\n", GetLastError());		return -1;

	}
	//Kill the target process
	DWORD ret = TerminateProcess(hProcess, 0);
	if (ret == 0) {
		wprintf(L"%d", GetLastError());
	}
	return -1;
}
int run() {
	//List processes
	HANDLE hSnApshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (hSnApshot != INVALID_HANDLE_VALUE) {
		PROCESSENTRY32 te = { sizeof(te) };
		BOOL f0k = Process32First(hSnApshot, &te);
		for (; f0k; f0k = Process32Next(hSnApshot, &te)) {
			wprintf(L"Pid: %d %s\n", te.th32ProcessID, te.szExeFile);
		}
	}
	CloseHandle(hSnApshot);
	//Kill em
	wprintf(L"the process's id which you want to kill:");
	int id = 0;
	wscanf(L"%d", &id);
	EnableDebugPriv(); //Request for higher priviledges
	pskill(id);
	return 0;
}
}