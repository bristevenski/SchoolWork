; Brianna Muleski - Program 4

segment .data

copymsg         db  "The result of calling strcpy is:",0
sourcemsg       db  "The source string is:",0
destmsg         db  "The destination string is:",0
catmsg          db  "The original string after calling strcat is:",0
cmpmsg          db  "Enter two strings to compare them:",0

segment .bss

str1             resb max_string_size
str2             resb max_string_size
str3             resb max_string_size
str4             resb max_string_size
str5             resb max_string_size
str1_length      resd 1

;.........................................................
;.........................................................
; A subprogram to read a string from keyboard
	
segment .text
read_string:
	push 	ebp
	mov 	ebp, esp
	
	mov 	ebx, [ebp + 8]
	mov 	esi, 0
	
	mov 	ecx, max_string_size

get_string:
	call 	read_char
	cmp  	al, 0xA
	je 		exit
	mov 	[ebx + esi], al
	add 	esi, 1
	loop 	get_string
exit:
	mov 	byte[ebx + esi], 0
	
    
	pop 	ebp
	ret
	
;.........................................................
;.........................................................
; A subprogram to return the length of a given string

segment .text
LengthIs:
	push 	ebp
	mov 	ebp, esp
	
	mov 	eax, 0
	mov 	ebx, [ebp + 8]
	mov 	esi, 0
	mov 	ecx, max_string_size
length_loop:
	cmp 	[ebx + esi], dword 0
	je 		length_exit
	inc 	eax
	add 	esi, 1
	loop 	length_loop

length_exit:
	pop 	ebp
	ret


;.........................................................
;.........................................................
; A subprogram strcpy copies one string into another
; strcpy(str2,str1)
; Result: str2 now equals str1

segment .text
strcpy:
	push 	ebp
	mov 	ebp, esp
	
	mov 	eax, 0
	mov 	edx, [ebp + 12]     ; str2: destination string
	mov 	ebx, [ebp + 16]     ; str1: source string
	mov 	esi, 0
	mov 	ecx, [ebp + 8]      ; length of source string

copy_loop:
	mov 	al, [ebx + esi]
	mov 	[edx + esi], al
	add 	esi, 1
	loop 	copy_loop
	

	pop 	ebp
	ret

	
;.........................................................
;.........................................................
; A subprogram strcat appends the contents of one string to the end of another
; strcat(str1,str2)
; Result: str1= str1 + str2

segment .bss

append_length 	resd 1

segment .text
strcat:
	push 	ebp
	mov 	ebp, esp
	
	mov 	edx, [ebp+16]     ; what we want to append
		
; find the length of what we want to append

	push 	edx
	call 	LengthIs
	add 	esp, 4
	mov 	[append_length], eax
	mov 	eax, 0
	
	mov 	ebx, [ebp + 12]     ; original string
	mov 	edx, [ebp + 16]     ; what we want to append
	mov 	ecx, [append_length] 
	mov 	edi, 0
	mov 	esi, [ebp + 8]  ; the last location of original string is where to append 

append_loop:
	mov 	al, [edx + edi]
	mov 	[ebx + esi], al
	add 	esi, 1
	add 	edi, 1
	loop 	append_loop
	
	pop 	ebp
	ret	

;.........................................................
;.........................................................
; A subprogram strcmp compares two strings
; strcmp(str1,str2)
; Result: returns a value less than, equal to, or greater than , depending on whether str1 is 
; less than, equal to, or greater than str2

;strcmp considers str1 to be less than str2 if
;The first i characters of str1 and str2 match, but the (i+1)st character of str1 is less than the (i+1)st character of str2 (for example, "abc" is less than "acc", and "abc" is less than "bcd"), or
;All characters of str1 match str2, but str1 is shorter than str2 (for example, "abc" is less than "abcd")

segment .data

islessmsg    	db " is less than",0x9,0
isequalsmsg  	db " is equal",0x9,0    ; 0x9 is the ASCII code of \t
firstflag    	dd 0
secondflag   	dd 0
segment .bss

first_length  	resd 1
second_length 	resd 1
loopcount     	resd 1


segment .text
strcmp:
	push 	ebp
	mov 	ebp, esp
	
		
; find the length of the first and second strings
	mov  	edx, [ebp + 12]     ; second string
	push 	edx
	call 	LengthIs
	add  	esp, 4
	mov 	[second_length], eax
	
	
	mov  	ebx, [ebp + 8]      ; first string
	push 	ebx
	call 	LengthIs
	add  	esp, 4
	mov 	[first_length], eax
   
	
	mov 	edx, [ebp + 12]     ; second string
	mov 	ebx, [ebp + 8]      ; first string
	mov 	[first_length], eax
	
	cmp 	eax, [second_length]
	je  	setcount
	jl  	setflag
	mov 	ecx, [second_length]
	mov 	[secondflag], dword 1  ; second is shorter
	jmp 	start
	
setflag:
	mov 	[firstflag], dword 1  ; first  is shorter 
setcount:	
	mov 	ecx, [first_length]   ; the two strings are equal
	
start:	
	mov 	eax, 0
	mov 	esi, 0
compare_loop:
	mov 	al, [ebx + esi]
	mov 	ah, [edx + esi]
	cmp 	al, ah
	jl  	FirstIsless
	jg  	SecondIsless
	add 	esi, 1	
	loop 	compare_loop
	
	cmp 	[firstflag], dword 1
	je  	FirstIsless
	cmp 	[secondflag], dword 1
	je  	SecondIsless
	
	mov 	eax, ebx
	call 	print_string
	mov  	eax, isequalsmsg
	call 	print_string
	mov 	eax, edx
	call 	print_string
	call 	print_nl
	jmp 	exitcmp
	
	
FirstIsless:
	mov 	eax, ebx
	call 	print_string
	mov 	eax, islessmsg
	call 	print_string
	mov 	eax, edx
	call 	print_string
	call 	print_nl
	jmp 	exitcmp
	
SecondIsless:
	mov 	eax, edx
	call 	print_string
	mov 	eax, islessmsg
	call 	print_string
	mov 	eax, ebx
	call 	print_string
	call 	print_nl	

	
exitcmp:	

	pop 	ebp
	ret 