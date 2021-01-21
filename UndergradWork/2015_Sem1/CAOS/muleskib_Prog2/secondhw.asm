; Brianna Muleski - homework 2

%include "asm_io.inc"
segment .data

prompt 		db "Enter number of lockers: ", 0
answer1 	db "There are ", 0
answer2 	db " opened lockers.", 0

segment .bss

divcount	resd 1
opencount	resd 1
input 		resd 1
cur 		resd 1
innercount	resd 1

segment .text
        global  _asm_main
_asm_main:
        enter   0,0               ; setup routine
        pusha

		mov		dword[divcount], 0
		mov		dword[opencount], 0
		
		;get number of lockers
		mov		eax, prompt
		call	print_string
		call	read_int
		mov		dword[input], eax

		;open locker loop
		mov		ecx, dword[input]
		
		outer:
			mov	dword[innercount], ecx
			inner:
				cmp		dword[innercount], 0
				je		innerdone
				mov		eax, ecx
				mov		ebx, dword[innercount]
				cdq
				div		ebx
				cmp		edx, 0
				jne		false
				inc		dword[divcount]
			false:
				dec		dword[innercount]	
				jmp		inner
			innerdone:
				mov		eax, dword[divcount]
				mov		ebx, 2
				cdq
				div		ebx
				cmp		edx, 0
				je		outerdone
				inc		dword[opencount]
			outerdone:
				mov		dword[divcount], 0
		loop	outer
		
		;print results
		mov		eax, answer1
		call	print_string
		mov		eax, dword[opencount]
		call	print_int
		mov		eax, answer2
		call	print_string		

        popa
        mov     eax, 0            ; return back to C
        leave
        ret
