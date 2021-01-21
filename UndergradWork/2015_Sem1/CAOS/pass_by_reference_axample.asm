; Call by reference example
%include "asm_io.inc"

segment .data

input1msg	db	"enter first integer: ", 0
input2msg	db	"enter second integer: ", 0

segment .bss

input1 	resd	1
input2	resd	1

segment .text
global _asm_main
_asm_main:
		enter 0,0
		pusha
		
		mov		eax, input1msg
		call	print_string
		call	read_int
		mov		dword[input1], eax
		
		mov		eax, input2msg
		call	print_string
		call	read_int
		mov		dword[input2], eax
		
		push	input2		; pass by reference
		push	input1		; pass by reference
		call	swap
		add		esp, 8 		;8 = 4 * number of parameters
		
		popa
		mov		eax, 0
		leave
		ret

;-----------------------------------------------
;-----------------------------------------------
; sub-program swap (value returning function)
segment .data

segment .bss

segment .text
swap:
		push	ebp			;save the current value of ebp
		mov		ebp, esp	
		sub		esp, 4		;saves two rooms for local variables (8 = 4 * number of variables)
		
		mov		ebx, [ebp + 8]
		mov		eax, [ebx]
		mov		[ebp -4], eax
		
		;return to main program
		add		esp, 4		;removes local variables from the stack (8 = 4 * number of variables)
		popa	ebp
		ret