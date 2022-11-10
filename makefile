wc:
	wc -l `find . -name \*.cs | grep -v /obj/` | tee wc.txt
