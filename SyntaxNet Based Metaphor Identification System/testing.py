# -*- coding: utf-8 -*-
"""
@author: DeeGee
"""

from wiktionaryparser import WiktionaryParser
from nltk.corpus import wordnet
import requests
import urllib3

#Disable insecure warning
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


#Pick out adjective-noun pairs from amod
adjNoun = [["one-horse", "race"]]
print (adjNoun)

print('-----------Checking for idiom-----------')
#print(adjNoun[0][0] + ' ' + adjNoun[0][1])

#Checks adj noun array for being idiom in Wiktionary
for i in range(len(adjNoun)):
    phrase = adjNoun[i][0] + ' ' + adjNoun[i][1]
#    print (phrase)
    parser = WiktionaryParser()
    idiomCheck = parser.fetch(phrase)
#    print(idiomCheck)
    if len(idiomCheck[0]['definitions']) > 0: 
        if any("idiomatic" in s for s in idiomCheck[0]['definitions'][0]['text']):
            print( "'" + adjNoun[i][0] + ' ' + adjNoun[i][1] + "'" + ' ' + 'is an idiom therefore it will not be considered')
            adjNoun.pop(i)

#Checks number of definitions 
defLengthArr = []
decisionArr = []
for i in range(len(adjNoun)):
    print("-------------Checking # of Definition---------")
#    print(adjNoun)
    defLengthArr.append([])
    print("Word: " + adjNoun[i][0])
    syns = wordnet.synsets(adjNoun[i][0])
    for x in range(len(syns)):
        defLengthArr[i] = x
print(defLengthArr)
for i in range(len(defLengthArr)):
    if(defLengthArr[i] == 1):
        decisionArr = "LITERAL"
        print(decisionArr)
    else:
        syns = wordnet.synsets(adjNoun[i][1])
        for j in range(len(syns)):
            if(len(syns) < 1):
                decisionArr = "UNDECIDED"
                print(decisionArr)
                break

#Check if collocates are nouns
nounArr = []
if not decisionArr:
    print("=========Checking for collocated nouns===========")
#    print(adjNoun)
    for i in range(len(adjNoun)):
        print("-----Checking for collocations of " + adjNoun[i][0] + "-------")
        nounArr.append([])
        result = requests.get('http://www.just-the-word.com/api/combinations?word=' + adjNoun[i][0]).json()
        nouns = {x.name().split('.', 1)[0] for x in wordnet.all_synsets('n')}
        for f in range(len(result['combinations'][0]['list'])):
            x = result['combinations'][0]['list'][f][2].replace(adjNoun[i][0], '').split()
            for e in range(len(x)):
                if(x[e] in nouns):
#                    print(x[e] + " is a noun")
                    nounArr[i].append(x[e])
#print(nounArr)

print('------Getting concrete nouns-----')
#Concrete noun measure
concMRaw = []
concMClean = []
for (i,row) in enumerate(nounArr):
    concMRaw.append([])
    for (j,value) in enumerate(row):
#        print(i)
        payload = {"Word": value}
        myheaders=  {
                        "Content-type": "application/json",
                        "Accept": "application/json"
                    }
        NounCol = requests.post(url='https://localhost:44315/api/ConRatings', headers=myheaders, json=payload, verify=False).json()
#        if NounCol == []:
#        x = NounCol[i]['concM']
        concMRaw[i].append(NounCol)
#        print(NounCol)
#print(concMRaw[0])
print('--------Identifying concrete rating------------')
for i in range(len(concMRaw)):
#    print('---test------')
#    print(concMRaw[i])
    concMClean.append([])
    for j in range(len(concMRaw[i])):
        concMClean[i].append([])
        for k in range(len(concMRaw[i][j])):
            if concMRaw[i] != []:   
                concMClean[i][j].append(concMRaw[i][j][0]['word'])
                concMClean[i][j].append(concMRaw[i][j][0]['concM'])

#print(concMClean) 

#arrTemp = []
print('------Sorting top 100---------')
#Remove empty entries from the array 
#print(len(concMClean[1]))
for i in range(len(concMClean)):
    for j in range(len(concMClean[i])):
#        if concMClean[i][j]==[]:
        concMClean[i] = [x for x in  concMClean[i] if x != []]
#print(len(concMClean[1]))
#print(concMClean)

for h in range(len(concMClean)):
#    print(h)
#    arrTemp.append([])
    for i in range(len(concMClean[h])):
#        print(concMClean[h][i])
#        print(h)
        for j in range(i+1,len(concMClean[h])):
#        if i + 1 < len(concMClean[h]):
#            if concMClean[h][i+1]!=[] or concMClean[h][i+1] != []:
#                 print(concMClean[h][i][1])
#            print(concMClean[h][i][1])
            if concMClean[h][i][1] < concMClean[h][j][1]:
#                arrTemp = []
#                print(arrTemp)
##                print(concMClean[h][i][1])
                arrTemp = concMClean[h][i]
                concMClean[h][i] = concMClean[h][j]
                concMClean[h][j] = arrTemp
#print(arrTemp)
#print('========COncMClean===========')
#print(concMClean)

#top 100
print('-------Top 100--------')
print('-------Results--------')
topConc = []
for i in range(len(concMClean)):
    topConc.append([])
    for j in range(len(concMClean[i])):
        if j < 100:
            topConc[i].append(concMClean[i][j][0])
#    for j in range(100):
#        if concMClean[i] != []:
#            if len(concMClean[i]) < 100:
#                print("Bitch boy!!!")
#                break
#            else:
#                topConc[i].append(concMClean[i][j][0])
    
#    Get result for each list of top 100 adj noun rhips
#    print(topConc[i])
    result = requests.get('https://localhost:44315/api/ArraySort?noun={0}&words={1}'.format(adjNoun[i][1],topConc[i]), verify=False).json() 
    print("{0} {1}".format(adjNoun[i], result))
           
        
        

