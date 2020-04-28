import os
os.environ["CORENLP_HOME"] = '\stanford-corenlp-full-2018-02-27'

from stanfordnlp.server import CoreNLPClient

# example text
print('---')
print('input text')
print('')
text = "Chris Manning is a nice person. Chris wrote a simple sentence. He also gives oranges to people."
print(text)
# set up the client
print('---')
print('starting up Java Stanford CoreNLP Server...')
# set up the client
with CoreNLPClient(annotators=['tokenize','ssplit','lemma','ner','depparse','coref'], timeout=30000, memory='16G') as client:
    # submit the request to the server
    ann = client.annotate(text)
    # get the first sentence
    sentence = ann.sentence[0]
#get the dependency parse of the first sentence
    print('---')
    print('dependency parse of first sentence')
    dependency_parse = sentence.basicDependencies
    print(dependency_parse)

