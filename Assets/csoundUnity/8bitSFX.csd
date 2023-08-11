<Cabbage>
form caption("Untitled") size(400, 300), guiMode("queue") pluginId("def1")


button bounds(62, 86, 80, 40) channel("trig")
hslider bounds(56, 146, 150, 50) channel("coinfreq") range(0, 1, 0, 1, 0.001)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -+rtmidi=NULL -M0 -m0d 
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1


instr 1
    kTrig chnget "trig"
    if changed(kTrig) == 1 then
        event "i", "cherry", 0, .5
    endif
endin


instr coin
    kFreq chnget "coinfreq"
    kEnv madsr 0.01, 0.1, 0.01, 0.01
    aSig vco2 0.5, kFreq
    outs aSig*kEnv, aSig*kEnv
endin


instr bullet
    aExp expon 1, p3, 0.001
    kpitch = 400+(1-aExp)*400
    kEnv madsr 0.01, 0.1, 0.01, 0.01
    aSig vco2  0.5, kpitch
    outs aSig*kEnv, aSig*kEnv
endin

instr fire
    kEnv madsr 0.01, 0.1, 0.01, 0.01
    asig pluck 1, 1000, 1000, 0, 1, 0.1, 10
    outs asig*kEnv, asig*kEnv
endin

instr fire2
    kEnv madsr 0.01, 0.1, 0.01, 0.01
    asig pluck 1, 1500, 1500, 0, 1, 0.1, 10
    outs asig*kEnv, asig*kEnv
endin

instr cherry
    asig pluck 1, 900, 800, 0, 1, 1, 1
    outs asig, asig
endin

instr cherry2
    kEnv madsr 0.01, 0.1, 0.01, 0.01
    asig pluck 1, 1200, 1200, 0, 1, 0.1, 10
    outs asig*kEnv, asig*kEnv
endin


instr enemy
    aExp expon 0.001, p3, 1
    kpitch = 100+(1-aExp)*100
    asig pluck 1, kpitch, 200, 0, 1 
    outs asig, asig 
endin 


</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
f 1 0 16384 10 1
;starts instrument 1 and runs it for a week
i1 0 [60*60*24*7]

 
</CsScore>
</CsoundSynthesizer>


<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="background">
  <r>240</r>
  <g>240</g>
  <b>240</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
