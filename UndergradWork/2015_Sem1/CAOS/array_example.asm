%include "asm_io.inc"

segment .data

size		equ		5
inputmsg	db		"enter an integer: ", 0

segment .bss

A			resd	size

segment .text
global _asm_main
_asm_main:
		enter 0,0
		pusha
		
		mov		ebx, A
		mov		esi, 0
		mov		ecx, size
		
		reading_loop:
				mov		eax, inputmsg
				call	print_string
				call	read_int
				mov		[ebx + esi], eax
				add		esi, 4
				loop	reading_loop
				
		push	size
		push	A
		call	array_print
		add		esp, 8
		
		popa
		mov		eax, 0
		leave
		ret
		
;-------------------------------------------------------
segment .data
segment .bss
segment .text
array_print:
		push 	ebp
		mov		ebp, esp
		
		mov		ecx, [ebp + 12]  	;references size, for counter
		mov		ebx, [ebp + 8]   	;references array A
		mov		esi, ecx
		sub		esi, 1
		imul	esi, 4			 	;multiply to get correct size of array elements
		
		print:
				mov		eax, [ebx + esi]
				call	print_int
				sub		esi, 4
				loop	print
				
		pop		ebp
		ret
		
