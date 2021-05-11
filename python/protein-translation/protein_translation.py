def proteins(strand):
    encoding_table = {
    'AUG':'Methionine',
    'UUU':'Phenylalanine', 'UUC':'Phenylalanine',
    'UUA':'Leucine', 'UUG':'Leucine',
    'UCU':'Serine', 'UCC':'Serine', 'UCA':'Serine', 'UCG':'Serine',
    'UAU':'Tyrosine', 'UAC':'Tyrosine',
    'UGU':'Cysteine', 'UGC':'Cysteine',
    'UGG':'Tryptophan',
    'UAA':'STOP', 'UAG':'STOP', 'UGA':'STOP'}


    full_strand = [encoding_table[strand[i:i+3:]] for i in range(len(strand))[::3]]
    stop_index = full_strand.index('STOP') if 'STOP' in full_strand else len(full_strand)

    return full_strand[:stop_index]
