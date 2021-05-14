def to_rna(dna_strand:str) ->str:
    encoding_table = {'G':'C', 'C':'G','A':'U','T':'A'}
    return ''.join([encoding_table[c] for c in dna_strand])
