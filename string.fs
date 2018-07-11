\ TODO understand & clarify all below
: delete   ( addr u n -- )
\ Deletes first n bytes from buffer at addr, fills rest with blanks, string is u B long
OVER min >R   r@ - ( left over ) DUP 0>
IF  2DUP SWAP DUP   r@ +  -ROT SWAP MOVE  THEN  + R> BL FILL ;
: insert   ( string length buffer size -- ) \ insert string in front of buffer
ROT OVER MIN >R R@ - ( left over ) OVER DUP R@ + ROT MOVE R> MOVE ;

: $padding   ( n -- n' ) \ rounds up to multiples of four cells
[ 6 cells ] LITERAL + [ -4 cells ] LITERAL AND ;
: $!   ( addr 1 u addr2 -- ) \ stored string at address
DUP @ IF  DUP @ FREE THROW  THEN
OVER $padding ALLOCATE THROW
OVER ! @ OVER >R  ROT OVER CELL+  R> MOVE 2DUP ! + CELL+ BL SWAP C! ;
: $@   ( addr 1 -- addr2 u )  @ DUP CELL+ SWAP @ ; \ returns stored string
: $@len   ( addr -- u ) @ @ ; \ returns length of string
: $!len   ( u addr -- ) \ changes length of string
OVER $padding OVER @ SWAP RESIZE THROW OVER ! @ ! ;
: $del   ( addr off u -- ) \ delete u B from string at ( addr + off )
>R >R DUP $@ R>  /string r@ DELETE
DUP $@len R> -- SWAP $!len ;
