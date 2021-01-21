; CS 3230 Computer Architecture and Operating Systems
; file: call.asm
; This program shows how calling by reference and value work
; 
;
; To create executable :
; nasm -f elf call.asm
; gcc -m32 call.o driver.c asm_io.o
; ./a.exe or ./a.out

%include "asm_io.inc"
;
; initialized data is put in the .data segment
;
segment .data
;
; These labels refer to strings used for output
;
prompt1 db    "Enter a number: ", 0       ; don't forget nul terminator
msgref  db    "The input after call by ref: ", 0
msgval  db    "The input after call by val: ", 0
;
; uninitialized data is put in the .bss segment
;
segment .bss
;
; These labels refer to double words used to store the inputs
;
input1  resd 1


;
; code is put in the .text segment
;
segment .text
global  _asm_main
_asm_main:
	enter   0,0               ; setup routine
	pusha

	mov     eax, prompt1      ; print out prompt
	call    print_string
	call    read_int          ; read integer
	mov    [input1],eax
		
       ; calling by value
	push    dword[input1]     ; push parameter as call by value
	call    call_val
	add     esp,4             ; recover the stack: remove all pushed parameters 
			
	mov     eax, msgval       ; print out prompt
	call    print_string
	mov     eax,[input1]
	call    print_int
	call    print_nl
		
		
	; calling by reference
	push    input1       ; push parameter as call by reference
	call    call_ref
	add     esp,4		 ; recover the stack: remove all pushed parameters
			
	mov     eax, msgref      ; print out prompt
	call    print_string
	mov     eax,[input1]
	call    print_int
	call    print_nl
	call    print_nl
        
	
	popa
	mov     eax, 0            ; return back to C
	leave                     
	ret

;.........................................................
;.........................................................		
; subprogram works as calling by reference

segment .text
call_ref:
	push ebp
	mov  ebp,esp
		  
	mov  ebx,[ebp+8]
	inc  dword[ebx]
		  
	pop  ebp
	ret 
	  
;.........................................................
;.........................................................	  
; subprogram works as calling by value

segment .text
call_val:

	push ebp
	mov  ebp,esp
		
	inc  dword[ebp+8]
		
	pop ebp
	ret 