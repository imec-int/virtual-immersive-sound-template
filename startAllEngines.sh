#! /bin/bash
#start midi2iosono
./midi2iosono

#sleep 5 sec
sleep 1 

#start pure data
#for flags and all that https://puredata.info/docs/faq/commandline
#use listdev to get exact names for audio/midi devices

/Applications/Pd-extended.app/Contents/Resources/bin/./pd -midiaddoutdev "MIDI-2-IOSONO" -audiooutdev 1 -channels 8 -open "PDpatch/doebeurs.pd"

#start unity? 



