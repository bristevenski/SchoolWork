%include "asm_io.inc"

segment .data

segment .bss

segment .text
global _asm_main
_asm_main:
		enter 0,0
		pusha
		
		push 	dword 7
		push	dword 5
		call	calc
		add		esp, 8 		;8 = 4 * number of parameters
		
		popa
		mov		eax, 0
		leave
		ret

;-----------------------------------------------
;-----------------------------------------------
; sub-program calc (void function)
segment .data

diffmsg	db	"diff is: ", 0
summsg	db	"sum is: ", 0

segment .bss

segment .text
calc:
		push	ebp			;save the current value of ebp
		mov		ebp, esp	
		sub		esp, 8		;saves two rooms for local variables (8 = 4 * number of variables)
		
		;difference
		mov		eax, dword[ebp + 8]
		sub		eax, dword[ebp + 12]
		mov		dword[ebp - 4], eax
		
		;sum
		mov		eax, dword[ebp + 8]
		add		eax, dword[ebp + 12]
		mov		dword[ebp - 8], eax
		
		;print results
		mov		eax, diffmsg
		call	print_string
		mov		eax, dword[ebp -4]
		call	print_int
		call	print_nl
		
		mov		eax, summsg
		call	print_string
		mov		eax, dword[ebp - 8]
		call	print_int
		call	print_nl
		
		;return to main program
		add		esp, 8		;removes local variables from the stack (8 = 4 * number of variables)
		popa	ebp
		ret