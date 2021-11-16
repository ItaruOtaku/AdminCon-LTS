#pragma warning(suppress : 4996)
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <String>
#include <algorithm>
#include <stdio.h>
#include <windows.h>
#include <winbase.h>
#include <tlhelp32.h>
#pragma comment(lib,"kernel32.lib")
#pragma comment(lib,"advapi32.lib")
using namespace std;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ACW32.CPP
 * Intro: Win32 version of AdminCon
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
void bad_cmd_prompt()
{
	cout << "Error - Bad command." << endl;
	Beep(800, 80);
	Beep(600, 80);
}
string Upper(string text)
{
	transform(text.begin(), text.end(), text.begin(), ::toupper);
	return text;
}
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
int pskill(int id)
{
	HANDLE hProcess = NULL;
	hProcess = OpenProcess(PROCESS_TERMINATE, FALSE, id);
	if (hProcess == NULL) {
		wprintf(L"\nOpen Process failed:%d\n", GetLastError());
		return -1;
	}
	DWORD ret = TerminateProcess(hProcess, 0);
	if (ret == 0) {
		wprintf(L"%d", GetLastError());
	}
	return -1;
}
int main() {
	Beep(600, 400);
	Beep(800, 300);
	SetConsoleTitle(L"AdminCon Win32 - Shell");
	cout << "AdminCon Win32 Edition" << endl;
	cout << "(c) 2017-2021 Project Amadeus. All rights reserved.\n" << endl;
	cout << "\n\nType \"HELP\" to see available commands." <<
		"\n____________________________________________\n" << endl;
	string usrin;
	while (1)
	{
		try
		{
			cout << "\n\nac:win32/cli>";
			cin >> usrin;
			if (Upper(usrin) == "HELP")
			{
				cout << "\n\n";
				cout << "KILL - kill a process.\n" << endl;
				cout << "CLS  - Clear the console.\n" << endl;
				cout << "RUN  - Start a process.\n" << endl;
				cout << "LISP - List all processes.\n" << endl;
				cout << "QT   - Exit\n" << endl;
			}
			else if (Upper(usrin) == "KILL")
			{
				HANDLE hSnApshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
				if (hSnApshot != INVALID_HANDLE_VALUE) {
					PROCESSENTRY32 te = { sizeof(te) };
					BOOL f0k = Process32First(hSnApshot, &te);
					for (; f0k; f0k = Process32Next(hSnApshot, &te)) {
						wprintf(L"Pid: %d %s\n", te.th32ProcessID, te.szExeFile);
					}
				}
				CloseHandle(hSnApshot);
				try
				{
					wprintf(L"the process's id which you want to kill: ");
					int id = 0;
					wscanf(L"%d", &id);
					EnableDebugPriv();
					pskill(id);
				}
				catch (exception)
				{
					bad_cmd_prompt();
				}
			}
			else if (Upper(usrin) == "LISP")
			{
				HANDLE hSnApshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
				if (hSnApshot != INVALID_HANDLE_VALUE) {
					PROCESSENTRY32 te = { sizeof(te) };
					BOOL f0k = Process32First(hSnApshot, &te);
					for (; f0k; f0k = Process32Next(hSnApshot, &te)) {
						wprintf(L"Pid: %d %s\n", te.th32ProcessID, te.szExeFile);
					}
				}
				CloseHandle(hSnApshot);
			}
			else if (Upper(usrin) == "QT")
			{
				return 0;
			}
			else if (Upper(usrin) == "RUN")
			{
				try
				{
					cout << "Process name: ";
					string pname;
					cin >> pname;
					system(pname.c_str());
				}
				catch (exception)
				{
					bad_cmd_prompt();
				}
			}
			else if (Upper(usrin) == "CLS")
			{
				system("cls");
			}
			else
			{
				bad_cmd_prompt();
			}
		}
		catch (exception)
		{
			bad_cmd_prompt();
		}
	}
}