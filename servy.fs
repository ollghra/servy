#! /usr/bin/gforth

\ from https://bernd-paysan.de/httpd-en.html

warnings off

include string.fs

VARIABLE URL            \ Stores the URL (string)
VARIABLE POST-args      \ stores arguments of POST (string)
VARIABLE URL-args       \ stores arguments of the URL (string)
VARIABLE protocol       \ stores the protocol (string)
VARIABLE ?data          \ has data been returned
VARIABLE ?active        \ true for POST FIXME clarify either name or description
VARIABLE ?command       \ true  in the request line FIXME what?
